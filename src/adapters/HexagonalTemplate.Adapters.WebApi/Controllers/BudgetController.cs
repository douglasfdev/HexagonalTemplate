using HexagonalTemplate.Core.Application.Abstractions.Ports.Handlers;
using HexagonalTemplate.Core.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalTemplate.Adapters.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController(ILogger<BudgetController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterAsync(
        [FromServices] ICommandHandler<Command.RegisterBudgetCommand> handler,
        [FromBody] Command.RegisterBudgetCommand command,
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
            logger.LogError(ex, "Error occurred while registering budget");
            return BadRequest(ex);
        }
    }
    
    [HttpPost("category")]
    public async Task<IActionResult> AddCategoryAsync(
        [FromServices] ICommandHandler<Command.AddCategoryCommand> handler,
        [FromBody] Command.AddCategoryCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            await handler.Handle(command, cancellationToken);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    
    [HttpGet("category/{accountId}")]
    public async Task<IActionResult> AddCategoryAsync(
        [FromServices] IQueryHandler<Query.ListCategoryQuery, List<ViewModel.CategoryViewModel>> handler,
        [FromRoute] Guid accountId,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var result = await handler.Handle(new Query.ListCategoryQuery(accountId), cancellationToken);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while get category to budget");
            return BadRequest(ex);
        }
    }
}