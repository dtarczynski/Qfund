﻿using Qfund.Application.Common.Interfaces.Services;
using Qfund.Application.Transactions.Queries;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Transactions.Handlers;

public class GetUserTransactionsQueryHandler
{
    private readonly ITransactionsService transactionsService;

    public GetUserTransactionsQueryHandler(ITransactionsService transactionsService)
    {
        this.transactionsService = transactionsService;
    }

    public async Task<IEnumerable<QfundTransaction>> Handle(
        GetUserTransactionsQuery query,
        CancellationToken cancellationToken = default)
    {
        var transactions = await this.transactionsService.GetTransactions(query, cancellationToken);

        return transactions;
    }

}
