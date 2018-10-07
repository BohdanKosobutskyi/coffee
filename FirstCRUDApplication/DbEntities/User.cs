using FirstCRUDApplication.DbEntities;

namespace Coffee.Models
{
    public class User : BaseEntity
    {
        public string Phone { get; set; }

        public string Password { get; set; }
        
        public string RefreshToken { get; set; }
    }
}
