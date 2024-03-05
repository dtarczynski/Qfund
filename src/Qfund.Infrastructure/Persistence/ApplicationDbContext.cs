using Microsoft.EntityFrameworkCore;
using Qfund.Application.Common.Interfaces;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<QfundTransaction> Transactions { get; set; }
}
