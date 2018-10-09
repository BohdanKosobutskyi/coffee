using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.DbEntities.Mapping
{
    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.AddedDate).IsRequired();
            entityBuilder.Property(t => t.Image).IsRequired();
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.Likes).IsRequired();
        }
    }
}
