using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using AsaBloggerApi.Src.Models;
using AsaBloggerApi.Src.Models.DTO;
using Microsoft.IdentityModel.Tokens;

#pragma warning disable CS8604
namespace AsaBloggerApi.Src.Helpers
{
    public sealed class JwtUtils
    {

        public static string GenerateJSONWebToken(UserModel userModel, Config config)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.JwtSecret));
    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userModel.Username),
                new Claim(JwtRegisteredClaimNames.Sub, userModel.Password),

            };

            var token = new JwtSecurityToken(config.Issuer,
               config.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(config.JwtTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static bool ValidateToken(string token, Config config)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config.Issuer,
                    ValidAudience = config.Issuer,
                
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.JwtSecret))
                };

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
    }
}