﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Contracts.Authorization
{
    public class ConfirmModel
    {
        public string phone { get; set; }

        public string password { get; set; }
    }
}
