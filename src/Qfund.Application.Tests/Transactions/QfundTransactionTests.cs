using FluentAssertions;
using NSubstitute;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Application.Services;
using Qfund.Application.Transactions.Handlers;
using Qfund.Application.Transactions.Queries;
using Qfund.Domain.Transaction.Entities;
using Xunit;

namespace Qfund.Application.Tests.Transactions;

public class QfundTransactionTests
{
    [Fact]
    public async Task Can_Create_Transaction()
    {
        DateTime dateFrom = DateTime.UtcNow.AddDays(-1);
        DateTime dateTo = DateTime.UtcNow;

        var transactionsRepositoryMock = Substitute.For<ITransactionsRepository>();
        var transactions = new List<QfundTransaction>
        {
            new QfundTransaction { Date = DateTime.UtcNow.AddHours(-1), Quantity = 1 },
            new QfundTransaction { Date = DateTime.UtcNow.AddHours(-2), Quantity = 100 }
        };
        transactionsRepositoryMock.Get(dateFrom, dateTo).Returns(transactions);
        var transactionsServiceMock = new TransactionsService(transactionsRepositoryMock);

        var query = new GetUserTransactionsQuery(dateFrom, dateTo);
        var result = await new GetUserTransactionsQueryHandler(transactionsServiceMock).Handle(query);

        result.Should().HaveCount(2);
    }

}
