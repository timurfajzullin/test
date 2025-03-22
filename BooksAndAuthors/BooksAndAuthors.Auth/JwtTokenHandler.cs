using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BooksAndAuthors.Database.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BooksAndAuthors.Auth;

public class JwtTokenHandler
{

    public string GenerateToken(User user)
    {
        var claims = new List<Claim> {new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)};
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SecurityKey)),
            SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            JwtOptions.Issuer,
            JwtOptions.Audience,
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddMinutes(JwtOptions.ExpirationTime)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

