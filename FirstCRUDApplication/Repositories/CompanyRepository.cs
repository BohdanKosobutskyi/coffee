using Coffee.DbEntities;
using Coffee.Repositories.Interfaces;
using Coffee.DbEntities;

namespace Coffee.Repositories
{
    public class CompanyRepository : DbRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
