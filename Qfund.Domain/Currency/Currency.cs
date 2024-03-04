namespace Qfund.Domain.Currency;

public record Currency(
    Guid Id,
    string Symbol)
{
    public Guid Id { get; private set; } = Id;
    public string Symbol { get; private set; } = Symbol;
}
