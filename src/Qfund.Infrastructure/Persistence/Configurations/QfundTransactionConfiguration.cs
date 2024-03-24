using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qfund.Domain.Account;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Infrastructure.Persistence.Configurations;

public class QfundTransactionConfiguration : IEntityTypeConfiguration<QfundTransaction>
{
    public void Configure(
        EntityTypeBuilder<QfundTransaction> builder)
    {
        builder.ToTable("transactions");
        builder.Property(x => x.Id);
        builder.Property(x => x.Date);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.Commission);
        builder.Property(x => x.Price);
        builder.Property(x => x.Value);
        builder.Property(x => x.Kind);
        builder.Property(x => x.TransactionType);
        builder.Property(x => x.AccountId);
        builder
            .HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountId);
    }
}

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(
        EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");
        builder.Property(x => x.Name).HasColumnName("name");
    }
}
