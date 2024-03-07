using Qfund.Application.Transactions.Queries;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Common.Interfaces.Services;

public interface ITransactionsService
{
    Task<IEnumerable<QfundTransaction>> GetTransactions(
        GetUserTransactionsQuery query,
        CancellationToken cancellationToken = default);

    Task<bool> Add(
        QfundTransaction trans);
}
