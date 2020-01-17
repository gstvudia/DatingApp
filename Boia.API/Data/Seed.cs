using Boia.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Boia.API.Data
{
    public class Seed
    {
        public static void SeedUsers(Context context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");

                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach(var user in users)
                {
                    byte[] passwordhash, passwordsalt;
                    CreatePasswordHash("password", out passwordhash, out passwordsalt);

                    user.PasswordHash = passwordhash;
                    user.PasswordSalt = passwordsalt;
                    user.Username.ToLower();
                    context.Users.Add(user);                    
                }

                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
