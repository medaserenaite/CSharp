using Microsoft.EntityFrameworkCore;
 
namespace CRUDelicious2.Models
{
    public class CRUDcontext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public CRUDcontext(DbContextOptions<CRUDcontext> options) : base(options) { }
        public DbSet<Dish> dishes { get; set; }
    }
}