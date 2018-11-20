using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.DbEntities.Mapping
{
    public class RoleMap
    {
        public RoleMap(EntityTypeBuilder<Role> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(x => x.AddedDate).ValueGeneratedOnAdd().IsRequired();
            entityBuilder.Property(t => t.Title).IsRequired();
        }
    }
}
