using Microsoft.AspNetCore.Mvc;
using Qfund.Application.Transactions.Commands;
using Qfund.Application.Transactions.Queries;
using Qfund.Domain.Transaction.Entities;
using Wolverine;

namespace Qfund.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMessageBus messageBus;

    public TransactionsController(
        IMessageBus messageBus)
    {
        this.messageBus = messageBus;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(
        DateTime from,
        DateTime to)
    {
        if (to < from)
        {
            return BadRequest();
        }

        await this.messageBus.PublishAsync(new GetUserTransactionsQuery(from, to));
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        QfundTransaction transaction)
    {
        await this.messageBus.PublishAsync(new CreateUserTransactionCommand(transaction));

        return CreatedAtAction(nameof(Create), new { id = transaction.Id }, transaction);
    }
}
