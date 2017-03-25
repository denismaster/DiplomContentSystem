using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using System.Text;

namespace DiplomContentSystem.Core
{
    public class PasswordUtils
    {
        public static string Hash(string password)
        {
            //need to get salt not like this
            var saltString = "hello";
            var salt = Encoding.UTF8.GetBytes(saltString);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 4096,
                    numBytesRequested: 256 / 8));
            return hashed;
        }

        public static bool Verify(string password, string hash)
        {
            var hashedPassword = Hash(password);
            return hashedPassword.Equals(hash);
        }
    }
}
