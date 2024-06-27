using CuriousCatClone.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CuriousCatClone.Infrastructure.Utils
{
    public class JwtTokenHandler
    {
        private readonly IConfiguration _config;

        public JwtTokenHandler(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GenerateAccessToken(AppUser user)
        {
            var expirationDate = DateTime.UtcNow + TimeSpan.FromDays(7);
            var claims = new Dictionary<string, object>
            {
                { "Email", user.Email }
            };

            string secret = _config["Token:Secret"];
            byte[] bytes = Encoding.UTF8.GetBytes(secret);
            SymmetricSecurityKey securityKey = new(bytes);
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor descriptor = new()
            {
                Expires = expirationDate,
                IssuedAt = DateTime.UtcNow,
                Claims = claims,
                SigningCredentials = credentials
            };

            var jwtHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtHandler.CreateToken(descriptor);
            string accessToken = jwtHandler.WriteToken(securityToken);

            return accessToken;
        }
    }
}
