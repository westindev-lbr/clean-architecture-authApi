using System.Security.Cryptography;
using System.Text;
using alabarre.Application.Intefaces.Utiles;

namespace alabarre.Infrastructure.Utiles;

public class HashPassword : IHashPassword
{
    public string HashPasswd(string password)
    {
        // Instanciation de la fonction de hash SHA256
        SHA256 hash = SHA256.Create();
        // Encodage du mot de passe
        var passwordInBytes = Encoding.UTF8.GetBytes(password);
        // Hash du mot de passe
        var passwordHashed = hash.ComputeHash(passwordInBytes);
        // Conversion en string du hash
        return Convert.ToBase64String(passwordHashed);
    }
    


    internal byte[] GenerateSaltInternal(int byteLength)
    {
        byte[] buf = new byte[byteLength];
        var rng = new RNGCryptoServiceProvider();

        rng.GetBytes(buf);

        return buf;
    }

    public string GenerateSalt(int byteLength)
    {
        return Convert.ToBase64String(GenerateSaltInternal(byteLength));
    }
}
