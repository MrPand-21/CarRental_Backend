using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static Password CreateHash(string password) //oluşturma
        {
            using (var hmac = new HMACSHA512()) {  //burada yeni bir şifre hash ve salt ı oluşturuldur.

                byte[] passwordSalt = hmac.Key;
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return new Password { PasswordHash = passwordHash, PasswordSalt = passwordSalt };
            }
        }
        public static bool VerifyPassword (string password,Password encryptedPassword) //bubrda ise doğrulanır.
        {
            using (var hmac = new HMACSHA512(encryptedPassword.PasswordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != encryptedPassword.PasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
