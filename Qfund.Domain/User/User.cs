using Qfund.Domain.Transactions;

namespace Qfund.Domain.User;

public record User(
    IEnumerable<Transaction.Transaction> Transactions,
    Guid Id)
{
    public Guid Id { get; private set; } = Id;
    public IEnumerable<Transaction.Transaction> Transactions { get; private set; } = Transactions;
}
