using Meetify.Data;
using Meetify.Business.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetify.Models;

namespace Meetify.Business.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MeetifyContext _context;

        public UsersRepository(MeetifyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetByIdAsync(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(Users users)
        {
            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Users users)
        {
            _context.Users.Update(users);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}
