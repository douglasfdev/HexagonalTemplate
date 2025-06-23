using HexagonalTemplate.Core.Application.Abstractions.Ports.Handlers;
using HexagonalTemplate.Core.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalTemplate.Adapters.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ILogger<AccountController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromServices] ICommandHandler<Command.CreateAccountCommand> handler,
        [FromBody] Command.CreateAccountCommand command,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            await handler.Handle(command, cancellationToken);

            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating an account.");
            return BadRequest(ex);
        }
    }
}