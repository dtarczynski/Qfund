using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Infrastructure.Persistence.Configurations;

public class QfundTransactionConfiguration : IEntityTypeConfiguration<QfundTransaction>
{
    public void Configure(
        EntityTypeBuilder<QfundTransaction> builder)
    {
        builder.ToTable("transactions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Date).HasColumnName("date");
        builder.Property(x => x.Quantity).HasColumnName("quantity");
    }
}
