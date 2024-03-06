using Qfund.Application.Common.Interfaces;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Application.Common.Interfaces.Services;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Services;

public class TransactionsService(ITransactionsRepository transactionsRepository) : ITransactionsService
{
    public async Task<IEnumerable<QfundTransaction>> GetTransactions(CancellationToken cancellationToken)
    {
        return await transactionsRepository.GetAll(cancellationToken);
    }
}
