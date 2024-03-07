using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Application.Common.Interfaces.Services;
using Qfund.Application.Transactions.Queries;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Services;

public class TransactionsService(ITransactionsRepository transactionsRepository) : ITransactionsService
{
    public async Task<IEnumerable<QfundTransaction>> GetTransactions(
        GetUserTransactionsQuery query,
        CancellationToken cancellationToken)
    {
        return await transactionsRepository.Get(query.From, query.To, cancellationToken);
    }

    public Task<bool> Add(
        QfundTransaction trans)
    {
        return transactionsRepository.Add(trans);
    }
}
