using Microsoft.EntityFrameworkCore;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Common.Interfaces.Persistence;

public interface IApplicationDbContext
{
    public DbSet<QfundTransaction> Transactions { get; }

    public Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
