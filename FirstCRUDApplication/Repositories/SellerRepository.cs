using Coffee.DbEntities;
using Coffee.Repositories.Interfaces;
using FirstCRUDApplication.DbEntities;

namespace Coffee.Repositories
{
    public class SellerRepository : DbRepository<Seller>, ISellerRepository
    {
        public SellerRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
