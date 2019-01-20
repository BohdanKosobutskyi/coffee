using Coffee.DbEntities;
using Coffee.Models;
using System.Collections.Generic;

namespace Coffee.Repositories.Interfaces
{
    public interface IUserRepository : IDbRepository<User>
    {
        IEnumerable<User> GetByCompany(long companyId);
    }
}
