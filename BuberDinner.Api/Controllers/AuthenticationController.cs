using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(
    ISender mediator,
    IMapper mapper
) : ApiController
{
  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = mapper.Map<RegisterCommand>(request);

        var result = await mediator.Send(command);
    
    return result.Match(
      authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
      Problem
    );
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var command = mapper.Map<LoginQuery>(request);

    var result = await mediator.Send(command);

    return result.Match(
      authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
      Problem
    );
  }
}