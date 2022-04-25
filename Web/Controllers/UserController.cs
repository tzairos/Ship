using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShipWebService.Commands.Authenticate;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateUserCommand command)
    {
       return await  _mediator.Send(command);

    }
}