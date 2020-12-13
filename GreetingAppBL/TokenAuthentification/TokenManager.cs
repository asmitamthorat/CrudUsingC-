using GreetingAppModelLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Greetings.TokenAuthentification
{
    public class TokenManager:ITokenManager
    {
        private JwtSecurityTokenHandler tokenHandler;
        private byte[] secretKey;

        public TokenManager(IConfiguration cofiguration)
        {
            tokenHandler = new JwtSecurityTokenHandler();
            secretKey = Encoding.ASCII.GetBytes(cofiguration.GetSection("JwtSecretKey").Value);
        }

        public string GenerateToken(RegistrationModel registrationModel)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.Email, registrationModel.email)
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);   
        }

        public ClaimsPrincipal GetPrincipal(String token) {
            var claims = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.FromMinutes(120000)
            }, out SecurityToken validatedToken);
            return claims;
        }

        public string ValidateToken(string token)
        {
            ClaimsPrincipal principal = GetPrincipal(token);
            ClaimsIdentity identity = (ClaimsIdentity)principal.Identity;
            Claim userNameClaim = identity.FindFirst(ClaimTypes.Email);
            string email = userNameClaim.Value;
            return email;
        }
    }
}
