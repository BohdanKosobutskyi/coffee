using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.DbEntities.Mapping
{
    public class CommentMap
    {
        public CommentMap(EntityTypeBuilder<Comment> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Text).IsRequired();
            entityBuilder.Property(x => x.AddedDate).IsRequired();
            entityBuilder.HasOne(x => x.Post).WithMany().HasForeignKey(x => x.PostId);
            entityBuilder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
