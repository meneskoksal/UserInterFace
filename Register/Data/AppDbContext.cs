using Microsoft.EntityFrameworkCore;
using Register.Models;

namespace Register.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
