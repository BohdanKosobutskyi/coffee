using Coffee.DbEntities;
using Coffee.DbEntities.Mapping;
using System.Collections.Generic;

namespace Coffee.DbEntities
{
    public class User : BaseEntity
    {
        public string Phone { get; set; }

        public string Password { get; set; }
        
        public string RefreshToken { get; set; }

        public bool IsConfirm { get; set; }

        public List<UserCompany> UserCompanies { get; set; }
        
    }
}
