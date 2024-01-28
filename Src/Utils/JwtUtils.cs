using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AsaBloggerApi.Src.Models;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

#pragma warning disable CS8604
namespace AsaBloggerApi.Src.Helpers
{
    public class JwtUtils
    {

        public static string GenerateJSONWebToken(UserModel userModel, Config config)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.JwtSecret);
            var claims = new[] {
                new Claim("Username", userModel.Username),
                new Claim("Id", userModel.Id.ToString()),

            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(config.JwtTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static int? ValidateToken(string token, Config config)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config.Issuer,
                    ValidAudience = config.Issuer,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.JwtSecret))
                };
                IdentityModelEventSource.ShowPII = true;
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                return userId;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}