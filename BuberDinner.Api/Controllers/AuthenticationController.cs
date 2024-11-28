using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController(ISender mediator) : ApiController
{
  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = new RegisterCommand(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Password
    );

    var result = await mediator.Send(command);
    
    return result.Match(
      authResult => Ok(MapAuthResult(authResult)),
      Problem
    );
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var command = new LoginQuery(
      request.Email,
      request.Password
    );

    var result = await mediator.Send(command);

    return result.Match(
      authResult => Ok(MapAuthResult(authResult)),
      Problem
    );
  }

  private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
  {
    return new AuthenticationResponse(
      authResult.User.Id,
      authResult.User.FirstName,
      authResult.User.LastName,
      authResult.User.Email,
      authResult.Token
    );
  }
}