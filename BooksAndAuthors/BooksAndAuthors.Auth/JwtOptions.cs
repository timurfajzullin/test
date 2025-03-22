using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BooksAndAuthors.Auth;

public class JwtOptions
{
    public const string Issuer = "https://localhost:7236";
    public const string Audience = "https://localhost:7236";
    public const string SecurityKey = "this_is_my_private_secret_key_fo_the_jwt_token";
    public const int ExpirationTime = 5;
}