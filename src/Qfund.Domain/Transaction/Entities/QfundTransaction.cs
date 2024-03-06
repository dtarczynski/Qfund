using Qfund.Domain.Transactions;

namespace Qfund.Domain.Transaction.Entities;

/* public record QfundTransaction(
    Guid Id,
    DateTime Date,
    TransactionType Type,
    TransactionKind Kind,
    Account.Account Account,
    Asset.Asset Asset,
    Currency.Currency Currency,
    decimal Quantity,
    decimal Price,
    decimal Commission,
    decimal Value) : BaseEntity<Guid>
{
    public Guid Id { get; private set; } = Id;
    public DateTime Date { get; private set; } = Date;
    public TransactionType Type { get; private set; } = Type;
    public TransactionKind Kind { get; private set; } = Kind;
    public Account.Account Account { get; private set; } = Account;
    public Asset.Asset Asset { get; private set; } = Asset;
    public Currency.Currency Currency { get; private set; } = Currency;
    public decimal Quantity { get; private set; } = Quantity;
    public decimal Price { get; private set; } = Price;
    public decimal Commission { get; private set; } = Commission;
    public decimal Value { get; private set; } = Value;
}
*/

public record QfundTransaction : IBaseEntity<Guid>
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; } = DateTime.UtcNow;
    public decimal Quantity { get; init; }

    public QfundTransaction()
    {
        this.Id = Guid.NewGuid();
    }
}

public interface IBaseEntity<T>
{
    public T Id { get; init; }
}