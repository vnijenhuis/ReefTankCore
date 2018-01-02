using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ReefTankCore.Core
{
    public class EncryptionUtilities
    {
        private const int SaltSize = 16;
        private const int Iterations = 9870;
        private const int KeySize = 64;
        
        public static string GenerateKey(string password, out string salt)
        {
            string keyString;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, Iterations))
            {
                //Get salt from deriveBytes
                byte[] saltBytes = deriveBytes.Salt;

                //Define salt key by using a standard keysize.
                byte[] key = deriveBytes.GetBytes(KeySize);

                salt = Convert.ToBase64String(saltBytes);
                keyString = Convert.ToBase64String(key);
            }

            return keyString;
        }

        public static bool ValidateKey(string password, string key, string salt)
        {
            //Convert salt and key to a byte array
            var saltBytes = Convert.FromBase64String(salt);
            var keyBytes = Convert.FromBase64String(key);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                //Get byte array from the deriveBytes
                byte[] newKey = deriveBytes.GetBytes(KeySize);  // derive a n-byte key

                if (newKey.SequenceEqual(keyBytes))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
