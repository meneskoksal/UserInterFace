using Register.Models;

namespace Register.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByIdAsyncNoTracking(int id);
        
        Task<User> GetByNameAsync(string name);
        Task<User> GetByEmailAsync(string email);



        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
        
    }
}
