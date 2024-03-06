using Microsoft.EntityFrameworkCore;
using Qfund.Application.Common.Interfaces;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Infrastructure.Persistence.Repositories;

public class TransactionsRepository(IApplicationDbContext applicationDbContext) : ITransactionsRepository
{
    public async Task<IEnumerable<QfundTransaction>> GetAll(CancellationToken cancellationToken)
    {
        return await applicationDbContext.Transactions.ToListAsync(cancellationToken: cancellationToken);
    }
}
