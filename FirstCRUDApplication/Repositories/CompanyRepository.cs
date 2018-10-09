using Coffee.DbEntities;
using Coffee.Repositories.Interfaces;
using FirstCRUDApplication.DbEntities;

namespace Coffee.Repositories
{
    public class CompanyRepository : DbRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
