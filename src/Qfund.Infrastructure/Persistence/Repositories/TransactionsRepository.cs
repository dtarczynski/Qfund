using Microsoft.EntityFrameworkCore;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Infrastructure.Persistence.Repositories;

public class TransactionsRepository(ApplicationDbContext applicationDbContext) : ITransactionsRepository
{
    public async Task<IEnumerable<QfundTransaction>> GetAll(CancellationToken cancellationToken)
    {
        return await applicationDbContext.Transactions.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<bool> Add(
        QfundTransaction trans,
        CancellationToken cancellationToken)
    {
        applicationDbContext.Transactions.Add(trans);
        var result = await applicationDbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    public async Task<IEnumerable<QfundTransaction>> Get(
        DateTime queryFrom,
        DateTime queryTo,
        CancellationToken cancellationToken)
    {
        return await applicationDbContext.Transactions
            .Where(x => x.Date >= queryFrom && x.Date <= queryTo)
            .ToListAsync(cancellationToken);
    }
}
