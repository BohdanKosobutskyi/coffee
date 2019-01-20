using Coffee.DbEntities.Mapping;
using FirstCRUDApplication.DbEntities;
using System.Collections.Generic;

namespace Coffee.DbEntities
{
    public class Company : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAproved { get; set; }

        public string Phone { get; set; }

        public IEnumerable<UserCompany> UserCompany { get; set; }
    }
}
