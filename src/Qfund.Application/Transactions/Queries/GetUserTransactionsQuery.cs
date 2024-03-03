namespace Qfund.Application.Transactions.Queries;

public record GetUserTransactionsQuery(DateOnly From, DateOnly To)
{

}
