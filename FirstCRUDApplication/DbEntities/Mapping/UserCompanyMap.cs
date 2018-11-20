using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.DbEntities.Mapping
{
    public class UserCompanyMap
    {
        public UserCompanyMap(EntityTypeBuilder<UserCompany> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new {
                    t.CompanyId,
                    t.UserId
                });

            entityBuilder
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserCompany)
                .HasForeignKey(sc => sc.UserId);

            entityBuilder
                    .HasOne(sc => sc.Company)
                    .WithMany(c => c.UserCompany)
                    .HasForeignKey(sc => sc.CompanyId);
        }
        
    }
}
