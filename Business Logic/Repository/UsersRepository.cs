using Meetify.Business.IRepository;
using Meetify.Data;
using Meetify.Models;
using Microsoft.EntityFrameworkCore;

namespace Meetify.Business.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly MeetifyContext _db;
    public UsersRepository(MeetifyContext db) => _db = db;

    public async Task<IEnumerable<Users>> GetAllAsync()
        => await _db.Users.AsNoTracking().OrderBy(u => u.Id).ToListAsync();

    public Task<Users?> GetByIdAsync(long id)
        => _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

    public async Task<Users> CreateAsync(Users user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateAsync(Users user)
    {
        _db.Users.Update(user);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await _db.Users.FindAsync(id);
        if (entity is null) return false;
        _db.Users.Remove(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public Task<bool> EmailExistsAsync(string email, long? excludeId = null)
        => _db.Users.AnyAsync(u => u.Email == email && (excludeId == null || u.Id != excludeId));
}
