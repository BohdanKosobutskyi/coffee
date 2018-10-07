using Coffee.Models;
using FirstCRUDApplication.DbEntities;

namespace Coffee.DbEntities
{
    public class Comment : BaseEntity
    {
        public Post Post { get; set; }

        public int PostId { get; set; }

        public string Text { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
