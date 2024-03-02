using Microsoft.AspNetCore.Mvc;

namespace Qfund.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    public HelloController()
    {
    }

    [HttpGet(Name = "Hello")]
    public IActionResult Get()
    {
        return Ok("OK");
    }
}
