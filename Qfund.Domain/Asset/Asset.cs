namespace Qfund.Domain.Asset;

public record Asset(
    Guid Id,
    string Name)
{
    public Guid Id { get; private set; } = Id;
    public string Name { get; private set; } = Name;
}
