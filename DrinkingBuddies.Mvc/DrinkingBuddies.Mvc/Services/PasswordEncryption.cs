using System.Security.Cryptography;
using System.Text;

namespace DrinkingBuddies.Mvc.Services
{
    public static class PasswordEncryption
    {
        public static string GenerateSalt()
        {
            var buffer = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }

        public static string EncodePassword(string password, string salt)
        {
            byte[] passwordByte = Encoding.UTF8.GetBytes(password);
            byte[] saltByte = Encoding.UTF8.GetBytes(salt);

            var bytes = new byte[passwordByte.Length + saltByte.Length];

            Buffer.BlockCopy(passwordByte, 0, bytes, 0, passwordByte.Length);
            Buffer.BlockCopy(saltByte, 0, bytes, passwordByte.Length, saltByte.Length);

            var hash = HashAlgorithm.Create("MD5");
            var hashBytes = hash.ComputeHash(bytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
