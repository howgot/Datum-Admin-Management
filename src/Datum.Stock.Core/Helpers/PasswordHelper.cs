using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Datum.Stock.Core.Helpers
{
    public class PasswordHelper
    {

        public static bool VerifyPassword(string plainPassword, string salt, string hashedPassword)
        {
            var hashPlainPassword = GetHashedPassword(plainPassword, salt);

            return string.Equals(hashedPassword, hashPlainPassword, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string GetHashedPassword(string plainText, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: plainText,
                                                                        salt: Encoding.UTF8.GetBytes(salt),
                                                                        prf: KeyDerivationPrf.HMACSHA1,
                                                                        iterationCount: 10000,
                                                                        numBytesRequested: 256 / 8));

            return hashed;
        }


        public static string CreateRandomSalt()
        {
            byte[] _saltBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(_saltBytes);
            }
            return Convert.ToBase64String(_saltBytes);
        }

    }
}
