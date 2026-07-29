using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollectX.API.Common.CommonMethod
{
    public class CommonMethods
    {
        public static string GenerateToken(int userId, string email, string role, string secretKey)
        {
            var claims = new[]
           {
                new Claim( "UserId", userId.ToString()),
                new Claim( "Email", email),
                new Claim( "Role", role),
           };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    secretKey));

            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: "CollectXAPI",
                audience:
                    "CollectXUsers",

                claims: claims,

                expires:
                    DateTime.UtcNow.AddMinutes(30),

                signingCredentials:
                    credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
