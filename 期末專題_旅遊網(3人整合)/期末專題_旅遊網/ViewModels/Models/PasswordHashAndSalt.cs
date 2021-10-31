using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace 期末專題_旅遊網.ViewModels.Models
{
    public class PasswordHashAndSalt
    {
        internal void PasswordHashSalt(string password, out byte[] pwHashSalt, out byte[] salt)
        {
            //Hashed
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            //Salt
            byte[] salt1 = new byte[20];
            using (RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider())
            {
                Rng.GetBytes(salt1);
            }
            byte[] passwordConcatSalt = passwordBytes.Concat(salt1).ToArray();
            byte[] passwordHashedWithSalt = SHA256.Create().ComputeHash(passwordConcatSalt);

            pwHashSalt = passwordHashedWithSalt;
            salt = salt1;
        }

        //密碼+Salt取得Hash
        internal byte[] CheckPassword(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordConcatSalt = passwordBytes.Concat(salt).ToArray();
            byte[] passwordHashedWithSalt = SHA256.Create().ComputeHash(passwordConcatSalt);
            return passwordHashedWithSalt;
        }
    }
}