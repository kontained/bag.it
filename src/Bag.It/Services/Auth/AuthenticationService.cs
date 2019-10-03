using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Bag.It.Interfaces.Services.Auth;
using Bag.It.Models;

namespace Bag.It.Services.Auth
{
    public class AuthenticationService : IAuthenticationSevice
    {
        private readonly IOptions<AuthSettings> _authSettings;

        public AuthenticationService(IOptions<AuthSettings> authSettings)
        {
            _authSettings = authSettings;
        }

        public string GenerateTokenForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Actor, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                }),

                Issuer = _authSettings.Value.Issuer,
                Audience = _authSettings.Value.Audience,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        _authSettings.Value.GetSecretBytes()), 
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool IsUserAuthenticated(User user)
        {
            throw new NotImplementedException();
        }
    }
}