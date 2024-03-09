using Microsoft.EntityFrameworkCore;
using Qfund.Api;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Application.Common.Interfaces.Services;
using Qfund.Application.Services;
using Qfund.Application.Transactions.Handlers;
using Qfund.Infrastructure.Persistence;
using Qfund.Infrastructure.Persistence.Repositories;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IStartupFilter, DatabaseInitializer>();
builder.Services.AddTransient<ITransactionsRepository, TransactionsRepository>();
builder.Services.AddTransient<ITransactionsService, TransactionsService>();

builder.Host.UseWolverine(opts =>
{
    opts.Discovery.IncludeAssembly(typeof(GetUserTransactionsQueryHandler).Assembly);
    opts.PublishAllMessages().ToRabbitExchange("qfund-api", exchange =>
    {
        exchange.ExchangeType = ExchangeType.Direct;
        exchange.BindQueue("api-queue", "api-binding");
    });
    opts.ListenToRabbitQueue("api-queue").UseForReplies();
    opts.UseRabbitMq(rabbit =>
    {
        rabbit.HostName = "localhost";
    }).AutoProvision();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
