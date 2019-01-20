using Coffee.DbEntities;
using Coffee.DbEntities.Mapping;
using Coffee.Models;
using Coffee.Repositories.Interfaces;
using FirstCRUDApplication.DbEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Coffee.Repositories
{
    public class UserRepository : DbRepository<User>, IUserRepository
    {
        private CoffeeContext _context;

        public UserRepository(CoffeeContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> GetByCompany(long companyId)
        {
            var users = _context.Set<UserCompany>()
                .Include(u => u.User)
                .Where(uc => uc.CompanyId == companyId)
                .Select(item => item.User)
                .ToList();

            return users;
        }
    }
}
