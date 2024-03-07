using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Common.Interfaces.Services;

public interface ITransactionsService
{
    Task<IEnumerable<QfundTransaction>> GetTransactions(CancellationToken cancellationToken);

    Task<bool> Add(
        QfundTransaction trans);
}
