using Coffee.DbEntities.Mapping;
using Coffee.Repositories.Interfaces;
using Coffee.DbEntities;

namespace Coffee.Repositories
{
    public class UserCompanyRepository : DbRepository<UserCompany>, IUserCompanyRepository
    {
        public UserCompanyRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
