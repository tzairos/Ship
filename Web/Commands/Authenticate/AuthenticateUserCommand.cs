using MediatR;
namespace ShipWebService.Commands.Authenticate;
public class AuthenticateUserCommand : IRequest<AuthenticateResponse>
{
    public UserDTO User { get; set; }
}