using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //gelen şifreyle hash oluşur
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (passwordHash[i] != computedHash[i]) //oluşturulan hash ile kullanıcı hashleri karşılaştırılır
                    {
                        return false;
                    }                    
                }
                return false;
            }
        }
    }
}
