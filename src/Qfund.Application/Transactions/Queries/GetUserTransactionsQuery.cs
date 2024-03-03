// Copyright (c) Hitachi Energy. All rights reserved.

namespace Qfund.Application.Transactions.Queries;

public record GetUserTransactionsQuery(DateOnly From, DateOnly To)
{

}
