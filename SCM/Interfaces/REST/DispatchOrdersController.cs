using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using pc2u202114643.API.SCM.Domain.Services;
using pc2u202114643.API.SCM.Interfaces.REST.Resources;
using pc2u202114643.API.SCM.Interfaces.REST.Transform;

namespace pc2u202114643.API.SCM.Interfaces.REST;

/// <summary>
///     Controller that exposes Dispatch Order endpoints.
///     <author>u202114643</author>
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Dispatch Orders endpoint")]
public class DispatchOrdersController(IDispatchOrderCommandService dispatchOrderCommandService) : ControllerBase
{
    /// <summary>
    ///     Registers a new dispatch order in the system.
    /// </summary>
    /// <param name="resource">Resource that contains the payload sent by the client.</param>
    /// <returns>The created dispatch order resource.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a dispatch order",
        Description = "Creates a dispatch order applying DFC quality rules.",
        OperationId = "CreateDispatchOrder")]
    [SwaggerResponse(StatusCodes.Status201Created, "Dispatch order created successfully.", typeof(DispatchOrderResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The payload is invalid.")]
    public async Task<IActionResult> CreateDispatchOrder([FromBody] CreateDispatchOrderResource resource)
    {
        try
        {
            var command = CreateDispatchOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
            var dispatchOrder = await dispatchOrderCommandService.Handle(command);
            var dispatchOrderResource = DispatchOrderResourceFromEntityAssembler.ToResourceFromEntity(dispatchOrder);
            return CreatedAtAction(nameof(CreateDispatchOrder), new { id = dispatchOrder.Id }, dispatchOrderResource);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "An unexpected error occurred while creating the dispatch order." });
        }
    }
}
