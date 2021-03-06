﻿using Coffee.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DbEntities
{
    public class Role : BaseEntity
    {
        public string Title { get; set; }

        public IEnumerable<SellerRole> SellerRole { get; set; }
    }
}
