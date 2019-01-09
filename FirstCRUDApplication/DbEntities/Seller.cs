using FirstCRUDApplication.DbEntities;
using System.Collections.Generic;

namespace Coffee.DbEntities
{
    public class Seller : BaseEntity
    {
        public bool IsSeller { get; set; }

        public bool IsAdmin { get; set; }

        public long CompanyId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string RefreshToken { get; set; }

        public Company Company { get; set; }

        public IEnumerable<SellerRole> SellerRole { get; set; }
    }
}
