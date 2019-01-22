using Coffee.DbEntities;
using Coffee.DbEntities.Mapping;
using Coffee.Models;
using Coffee.Repositories.Interfaces;
using FirstCRUDApplication.DbEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public override IEnumerable<User> Get(Func<User,bool> predicate)
        {
            return _context.Set<User>().AsNoTracking().Include(item => item.UserCompanies);
        }

        public void DeleteUserFromCompany(long userId)
        {
            var user = _context.Set<User>().Include(uc => uc.UserCompanies).FirstOrDefault(item => item.Id == userId);

            var userCompany = user.UserCompanies.FirstOrDefault(item => item.UserId == userId);

            user.UserCompanies.Remove(userCompany);

            _context.SaveChanges();
        }
    }
}
