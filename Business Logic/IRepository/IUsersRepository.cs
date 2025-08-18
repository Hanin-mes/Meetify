using Meetify.Models;

namespace Meetify.Business.IRepository;

public interface IUsersRepository
{
    Task<IEnumerable<Users>> GetAllAsync();
    Task<Users?> GetByIdAsync(long id);
    Task<Users> CreateAsync(Users user);
    Task<bool> UpdateAsync(Users user);
    Task<bool> DeleteAsync(long id);

    // helpful for unique emails
    Task<bool> EmailExistsAsync(string email, long? excludeId = null);
}
