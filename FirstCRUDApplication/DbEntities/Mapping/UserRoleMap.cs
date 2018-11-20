using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.DbEntities.Mapping
{
    public class UserRoleMap
    {
        public UserRoleMap(EntityTypeBuilder<UserRole> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new {
                    t.RoleId,
                    t.UserId
                });

            entityBuilder
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserRole)
                .HasForeignKey(sc => sc.UserId);

            entityBuilder
                    .HasOne(sc => sc.Role)
                    .WithMany(c => c.UserRole)
                    .HasForeignKey(sc => sc.RoleId);
        }
    }
}
