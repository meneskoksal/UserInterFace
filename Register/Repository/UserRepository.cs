using Microsoft.EntityFrameworkCore;
using Register.Data;
using Register.Interfaces;
using Register.Models;

namespace Register.Repository
{
    
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        

        public  async Task<User> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefault(i => i.ID == id);
        }

        public async Task<User> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(i=>i.Name == name);

        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Email == email);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _context.Update(user);
            return Save();
        }

        
    }
}
