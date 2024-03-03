using Microsoft.AspNetCore.Mvc;
using Qfund.Application.Transactions.Queries;
using Wolverine;

namespace Qfund.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMessageBus _messageBus;

    public TransactionsController(
        IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        DateOnly from,
        DateOnly to)
    {
        await this._messageBus.PublishAsync(new GetUserTransactionsQuery(from, to));
        return Ok();
    }
}
