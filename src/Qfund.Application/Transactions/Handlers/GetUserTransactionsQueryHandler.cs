using Microsoft.EntityFrameworkCore;
using Qfund.Application.Common.Interfaces;
using Qfund.Application.Transactions.Queries;
using Qfund.Domain.Transaction;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Transactions.Handlers;

public class GetUserTransactionsQueryHandler
{
    private readonly IApplicationDbContext _dbContext;

    public GetUserTransactionsQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<QfundTransaction>> Handle(
        GetUserTransactionsQuery query)
    {
        var transactions = await _dbContext.Transactions.ToListAsync();

        return transactions;
    }

}
