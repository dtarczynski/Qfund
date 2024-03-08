using FluentAssertions;
using NSubstitute;
using Qfund.Application.Common.Interfaces.Persistence;
using Qfund.Application.Services;
using Qfund.Application.Transactions.Handlers;
using Qfund.Application.Transactions.Queries;
using Qfund.Domain.Transaction.Entities;
using Xunit;

namespace Qfund.Application.UnitTests;

public class TransactionsTests
{
    [Fact]
    public async Task Can_Create_Transaction()
    {
        // Arrange
        var to = DateTime.UtcNow;
        var from = to.AddYears(-1);
        var transactionsList = new List<QfundTransaction>
            {
                new QfundTransaction() { Date = from.AddDays(1), Quantity = 10 },
                new QfundTransaction() { Date = from.AddDays(2), Quantity = 100 }
            };

        var query = new GetUserTransactionsQuery(from, to);
        var transactionsRepositoryMock = Substitute.For<ITransactionsRepository>();
        transactionsRepositoryMock.Get(from, to)
            .Returns(transactionsList);

        var transactionsService = new TransactionsService(transactionsRepositoryMock);

        var handler = new GetUserTransactionsQueryHandler(transactionsService);

        // Act
        var result = await handler.Handle(query);

        // Assert
        result.Should().HaveCount(2);
        result.OrderBy(x => x.Date).First().Quantity.Should().Be(10);
    }
}
