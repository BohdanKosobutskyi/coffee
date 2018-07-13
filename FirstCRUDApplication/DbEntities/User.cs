using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class User : BaseEntity
    {
        public string Phone { get; set; }

        public string Password { get; set; }
        
        public string RefreshToken { get; set; }
    }
}
