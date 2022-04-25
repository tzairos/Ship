
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ShipWebService.Queries.GetShip;
using ShipWebService.Commands.AddShip;
using ShipWebService.Commands.UpdateShip;
using ShipWebService.Commands.DeleteShip;

namespace ShipWebService.Controllers;
[ApiController]
[Route("[controller]")]
[TypeFilter(typeof(ExceptionFilter))]
public class ShipController : ControllerBase
{

    private readonly IMediator _mediator;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ShipController> _logger;

    public ShipController(ILogger<ShipController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ShipDTO>>> GetBySpec([FromQuery]GetShipQuery query=null)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ShipDTO>> GetById(int id)
    {
        GetShipQuery query = new GetShipQuery();
        query.Id = id;
        var result = await _mediator.Send(query);
        return Ok(result.FirstOrDefault());
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> AddShip([FromBody]AddShipCommand ship)
    {
        var result = await _mediator.Send(ship);
        return Ok();
    }
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> UpdateShip([FromBody]UpdateShipCommand ship)
    {
        var result = await _mediator.Send(ship);
        return Ok();
    }
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> DeleteShip(DeleteShipCommand ship)
    {
        var result = await _mediator.Send(ship);
        return Ok();
    }
}
