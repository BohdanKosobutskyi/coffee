using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class PostCreateViewModel
    {
        public long company_id { get; set; }

        public string image { get; set; }

        public string description { get; set; }

        public string title { get; set; }
    }
}
