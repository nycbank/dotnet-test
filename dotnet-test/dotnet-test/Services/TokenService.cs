using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using dotnet_test.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_test.Services;

public static class TokenService
{
    public static string GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(Auth.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.Now.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Teste", "Testando")
            })
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }


}