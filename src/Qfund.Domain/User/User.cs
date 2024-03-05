namespace Qfund.Domain.User;

public record User(
    IEnumerable<Transaction.Entities.QfundTransaction> Transactions,
    Guid Id)
{
    public Guid Id { get; private set; } = Id;
    public IEnumerable<Transaction.Entities.QfundTransaction> Transactions { get; private set; } = Transactions;
}
