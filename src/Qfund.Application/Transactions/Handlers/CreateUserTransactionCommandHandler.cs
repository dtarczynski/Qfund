using Qfund.Application.Common.Interfaces.Services;
using Qfund.Application.Transactions.Commands;

namespace Qfund.Application.Transactions.Handlers;

public class CreateUserTransactionCommandHandler
{
    private readonly ITransactionsService transactionsService;

    public CreateUserTransactionCommandHandler(ITransactionsService transactionsService)
    {
        this.transactionsService = transactionsService;
    }

    public async Task<bool> Handle(
        CreateUserTransactionCommand command)
    {
        return await this.transactionsService.Add(command.Transaction);
    }
}
