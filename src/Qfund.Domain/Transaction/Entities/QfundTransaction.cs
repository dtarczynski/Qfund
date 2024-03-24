namespace Qfund.Domain.Transaction.Entities;

public record QfundTransaction : IBaseEntity<Guid>
{
    public Guid Id { get; }
    public DateTime Date { get; init; } = DateTime.UtcNow;
    public TransactionType TransactionType { get; init; }
    public TransactionKind Kind { get; init; }
    public decimal Quantity { get; init; }
    public Guid? AccountId { get; set; }
    public Account.Account? Account { get; private set; }
    // public Asset.Asset Asset { get; private set; }
    // public Currency.Currency Currency { get; private set; }
    public decimal Price { get; private set; }
    public decimal Commission { get; private set; }
    public decimal Value { get; private set; }

    public QfundTransaction()
    {
        this.Id = Guid.NewGuid();
    }
}

public interface IBaseEntity<T>
{
    public T Id { get; }
}