using Coffee.DbEntities.Mapping;
using Coffee.Repositories.Interfaces;
using FirstCRUDApplication.DbEntities;

namespace Coffee.Repositories
{
    public class UserCompanyRepository : DbRepository<UserCompany>, IUserCompanyRepository
    {
        public UserCompanyRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
