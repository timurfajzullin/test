using System.Security.Cryptography;
using System.Text;

namespace BooksAndAuthors.Auth.Services;

public class PasswordHasher
{

    public static int HashPassword(string password)
    {
        var passwordHash = password.GetHashCode();
        return passwordHash;
    }

    public static bool VerifyPassword(int hashedPassword, int providedPassword)
    {
        if (hashedPassword == providedPassword)
        {
            return true;
        }
        return false;
    }
}
