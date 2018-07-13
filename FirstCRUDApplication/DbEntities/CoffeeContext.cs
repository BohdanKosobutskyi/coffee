using Coffee.DbEntities;
using Coffee.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCRUDApplication.DbEntities
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext() 
            : base()
        {

        }

        public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            new UserMap(modelBuilder.Entity<User>());
        }
    }
}
