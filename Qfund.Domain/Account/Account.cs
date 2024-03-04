namespace Qfund.Domain.Account;

public record Account(
    Guid Id,
    string Name)
{
    public Guid Id { get; private set; } = Id;
    public string Name { get; private set; } = Name;
}
