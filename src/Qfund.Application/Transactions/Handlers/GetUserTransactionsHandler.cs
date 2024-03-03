// Copyright (c) Hitachi Energy. All rights reserved.

using Microsoft.Extensions.Logging;
using Qfund.Application.Transactions.Queries;

namespace Qfund.Application.Transactions.Handlers;

public class GetUserTransactionsHandler(ILogger<GetUserTransactionsHandler> logger)
{
    private readonly ILogger<GetUserTransactionsHandler> _logger = logger;

    public void Handle(
        GetUserTransactionsQuery query)
    {
        this._logger.LogDebug($"Handler {typeof(GetUserTransactionsHandler)} executed");
    }

}
