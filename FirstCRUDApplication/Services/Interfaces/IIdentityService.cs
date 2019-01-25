using Coffee.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Coffee.Services.Interfaces
{
    public interface IIdentityService
    {
        ClaimsIdentity GetIdentity(BaseEntity user);
    }
}
