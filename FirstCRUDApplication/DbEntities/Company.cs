using Coffee.DbEntities.Mapping;
using Coffee.Models;
using FirstCRUDApplication.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IEnumerable<UserCompany> UserCompany { get; set; }
    }
}
