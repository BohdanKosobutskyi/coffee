using Coffee.DbEntities;
using Coffee.Models;
using System;
using System.Collections.Generic;

namespace Coffee.Repositories.Interfaces
{
    public interface IUserRepository : IDbRepository<User>
    {
        IEnumerable<User> GetByCompany(long companyId);

        void RemoveUserFromCompany(long userId);

        IEnumerable<User> GetConfirmUsers(Func<User, bool> predicate);

        IEnumerable<User> GetNotConfirmUsers(Func<User, bool> predicate);
    }
}
