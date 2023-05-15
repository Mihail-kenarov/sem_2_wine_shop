using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Encryption
    {
        public static byte[] GenerateSalt()
        {

            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public static byte[] HashPassword(string password, byte[] salt)
        {

            byte[] saltedPassword = new byte[salt.Length + password.Length];
            Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
            Buffer.BlockCopy(password.ToCharArray(), 0, saltedPassword, salt.Length, password.Length);


            byte[] hashedPassword;
            using (var sha256 = new SHA256Managed())
            {
                hashedPassword = sha256.ComputeHash(saltedPassword);
            }

            return hashedPassword;
        }


        public static bool VerifyPassword(string password, byte[] salt, byte[] hashedPassword)
        {

            byte[] storedHashedPassword = HashPassword(password, salt);


            return hashedPassword.SequenceEqual(storedHashedPassword);
        }


    }
}
