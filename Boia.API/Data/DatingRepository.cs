using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boia.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Boia.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly Context _context;

        public DatingRepository(Context context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int Id)
        {
            var user = await _context.Users.Include(user => user.Photos).FirstOrDefaultAsync(user => user.Id == Id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(users => users.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
