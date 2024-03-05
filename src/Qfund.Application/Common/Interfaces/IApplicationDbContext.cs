using Microsoft.EntityFrameworkCore;
using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<QfundTransaction> Transactions { get; }
}
