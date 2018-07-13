using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
