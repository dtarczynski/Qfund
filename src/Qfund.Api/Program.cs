using JasperFx.Core;
using Microsoft.EntityFrameworkCore;
using Qfund.Application.Common.Interfaces;
using Qfund.Application.Transactions.Handlers;
using Qfund.Infrastructure.Persistence;

using Wolverine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Host.UseWolverine(opts => opts.Discovery.IncludeAssembly(typeof(GetUserTransactionsQueryHandler).Assembly));

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
