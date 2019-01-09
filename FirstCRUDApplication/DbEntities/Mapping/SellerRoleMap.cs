using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.DbEntities.Mapping
{
    public class SellerRoleMap
    {
        public SellerRoleMap(EntityTypeBuilder<SellerRole> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new {
                    t.RoleId,
                    t.UserId
                });

            entityBuilder
                .HasOne(sc => sc.Seller)
                .WithMany(s => s.SellerRole)
                .HasForeignKey(sc => sc.UserId);

            entityBuilder
                    .HasOne(sc => sc.Role)
                    .WithMany(c => c.SellerRole)
                    .HasForeignKey(sc => sc.RoleId);
        }
    }
}
