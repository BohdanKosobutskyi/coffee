using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Contracts.Company
{
    public class CompanyListView
    {
        public long company_id { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public bool is_approved { get; set; }
    }
}
