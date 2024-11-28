using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    /// <summary>
    /// Defines a contract for generating JWT tokens.
    /// </summary>
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user for whom to generate the token.</param>
        /// <returns>The generated JWT token.</returns>
        string GenerateToken(User user);
    }
}