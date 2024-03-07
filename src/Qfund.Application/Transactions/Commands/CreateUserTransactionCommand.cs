using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Transactions.Commands;

public record CreateUserTransactionCommand(QfundTransaction Transaction);
