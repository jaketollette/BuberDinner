using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;
using BuberDinner.Domain.Common.Errors;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
  IJwtTokenGenerator jwtTokenGenerator,
  IUserRepository userRepository
): IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}