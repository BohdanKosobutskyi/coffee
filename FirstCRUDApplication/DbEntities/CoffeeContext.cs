using Coffee.Configuration;
using Coffee.DbEntities;
using Coffee.DbEntities.Mapping;
using Coffee.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCRUDApplication.DbEntities
{
    public class CoffeeContext : DbContext
    {
        private readonly IConfigurableOptions _configurableOptions;
        public CoffeeContext() 
            : base()
        {
            
        }

        public CoffeeContext(DbContextOptions<CoffeeContext> options,IConfigurableOptions configurableOptions) : base(options)
        {
            _configurableOptions = configurableOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            new UserMap(modelBuilder.Entity<User>());
            new PostMap(modelBuilder.Entity<Post>());
            new CommentMap(modelBuilder.Entity<Comment>());
            new CompanyMap(modelBuilder.Entity<Company>());
            new UserCompanyMap(modelBuilder.Entity<UserCompany>());
            new SellerMap(modelBuilder.Entity<Seller>());
            new RoleMap(modelBuilder.Entity<Role>());
            new UserRoleMap(modelBuilder.Entity<UserRole>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_configurableOptions.DbConnection);
            base.OnConfiguring(builder);
        }
    }
}
