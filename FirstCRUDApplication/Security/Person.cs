using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Security
{
    public class Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string RefreshToken { get; set; }
    }
}
