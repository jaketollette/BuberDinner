using MediatR;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Commands.Register;
using ErrorOr;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;

public class RegisterCommandHandler(
  IJwtTokenGenerator jwtTokenGenerator,
  IUserRepository userRepository
) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
      if (userRepository.GetUserByEmail(command.Email) is not null)
      {
        return Errors.User.DuplicateEmail;
      }

      User user = new ()
      {
        FirstName = command.FirstName,
        LastName = command.LastName,
        Email = command.Email,
        Password = command.Password
      };

      userRepository.Add(user);

      var token = jwtTokenGenerator.GenerateToken(user);

      return new AuthenticationResult(user, token);
    }
}