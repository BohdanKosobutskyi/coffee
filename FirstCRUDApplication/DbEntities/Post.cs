using Coffee.Models;
using FirstCRUDApplication.DbEntities;

namespace Coffee.DbEntities
{
    public class Post : BaseEntity
    {
        public string Image { get; set; }

        public string Title { get; set; }

        public int Likes { get; set; }
    }
}
