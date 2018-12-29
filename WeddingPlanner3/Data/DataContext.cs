using Microsoft.EntityFrameworkCore;
using WeddingPlanner3.Models;

namespace WeddingPlanner3.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Guest> Guests { get; set; }

    }
}
