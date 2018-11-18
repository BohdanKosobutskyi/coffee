using FirstCRUDApplication.DbEntities;

namespace Coffee.DbEntities
{
    public class Seller : BaseEntity
    {
        public bool IsSeller { get; set; }

        public bool IsAdmin { get; set; }

        public long CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
