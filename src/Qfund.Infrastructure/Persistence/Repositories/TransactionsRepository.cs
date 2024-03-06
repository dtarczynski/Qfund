using Microsoft.EntityFrameworkCore;
using Qfund.Application.Common.Interfaces;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Infrastructure.Persistence.Repositories;

public class TransactionsRepository(ApplicationDbContext applicationDbContext) : ITransactionsRepository
{
    public async Task<IEnumerable<QfundTransaction>> GetAll(CancellationToken cancellationToken)
    {
        return await applicationDbContext.Transactions.ToListAsync(cancellationToken: cancellationToken);
    }

    public void Add(
        QfundTransaction trans,
        CancellationToken cancellationToken)
    {
        applicationDbContext.Transactions.Add(trans);
        applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
