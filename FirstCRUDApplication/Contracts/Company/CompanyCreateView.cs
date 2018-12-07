using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Contracts.Company
{
    public class CompanyCreateView
    {
        public string email { get; set; }
        public string title { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
    }
}
