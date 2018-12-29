using Microsoft.EntityFrameworkCore;
 
namespace LoginAndRegistration2.Models
{
    public class DataContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public static object Users { get; internal set; }

        // This DbSet contains "Person" objects and is called "Users"
        public DbSet<User> users { get; set; }
    }
}