using MediatR;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities.ShipAggreate;
using ApplicationCore.Entities.UserAggreate;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace ShipWebService.Commands.Authenticate;
public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateResponse>
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;
private readonly AppSettings _appSettings;
    public AuthenticateUserCommandHandler(IOptions<AppSettings> appSettings,IUserService userService,IMapper mapper)
    {
        _userService=userService;
        _mapper=mapper;
        _appSettings=appSettings.Value;
    }  
    public async Task<AuthenticateResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var result= await _userService.GetUser(request.User.Username,request.User.Password);
        var user=_mapper.Map<UserDTO>(result);
        user.Token=GenerateJwtToken(user);
        return new AuthenticateResponse(user);
    }
      private string GenerateJwtToken(UserDTO user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}