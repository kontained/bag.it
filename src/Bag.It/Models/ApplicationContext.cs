using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Bag.It.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users { get; set; }
    }
}