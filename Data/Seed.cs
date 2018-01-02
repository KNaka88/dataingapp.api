using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatingApp.Api.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }
        public void SeedUsers()
        {
            // Make Database empty
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();

            // seed users
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<Models.User>>(userData);
            foreach (var user in users)
            {
                // create the password hash        
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordHash;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
            }
            
            _context.SaveChanges();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // out modifier : look up page121

            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}