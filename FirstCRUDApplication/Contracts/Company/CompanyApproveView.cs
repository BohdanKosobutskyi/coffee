using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Contracts.Company
{
    public class CompanyApproveView
    {
        public long company_id { get; set; }
        public bool is_approves { get; set; }
    }
}
