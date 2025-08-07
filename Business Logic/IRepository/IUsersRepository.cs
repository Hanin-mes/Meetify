using Meetify.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetify.Business.IRepository
{
    public interface IUsersRepository
    {//testing github test tes 
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(long id);
        Task AddAsync(Users users);
        Task UpdateAsync(Users users);
        Task DeleteAsync(long id);
    }
}
