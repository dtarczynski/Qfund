using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly string? schema;
    private const string DefaultSchema = "qf";

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        this.schema = configuration.GetSection("DatabaseSchema").Value ?? DefaultSchema;
    }

    public DbSet<QfundTransaction> Transactions { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema(this.schema ?? DefaultSchema);

        base.OnModelCreating(modelBuilder);
    }
}
