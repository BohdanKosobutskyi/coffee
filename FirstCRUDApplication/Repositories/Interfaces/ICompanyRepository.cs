﻿using Coffee.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Repositories.Interfaces
{
    public interface ICompanyRepository : IDbRepository<Company>
    {
    }
}