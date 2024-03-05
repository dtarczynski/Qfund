using Qfund.Application.Transactions.Queries;
using Xunit;

namespace Qfund.Application.Tests.Transactions;

public class QfundTransactionTests
{
    [Fact]
    public void Can_Create_Transaction()
    {
        DateOnly dateFrom = DateOnly.MinValue;
        DateOnly dateTo = DateOnly.FromDateTime(DateTime.UtcNow);

        var query = new GetUserTransactionsQuery(dateFrom, dateTo);
        // new GetUserTransactionsQueryHandler().Handle(query);
    }

}
