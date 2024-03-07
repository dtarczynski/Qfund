using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Common.Interfaces.Persistence;

public interface ITransactionsRepository
{
    Task<IEnumerable<QfundTransaction>> GetAll(CancellationToken cancellationToken);

    Task<bool> Add(
        QfundTransaction trans,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<QfundTransaction>> Get(
        DateTime queryFrom,
        DateTime queryTo,
        CancellationToken cancellationToken = default);
}
