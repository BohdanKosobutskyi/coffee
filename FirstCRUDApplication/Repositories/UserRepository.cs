using Coffee.DbEntities;
using Coffee.Models;
using Coffee.Repositories.Interfaces;
using FirstCRUDApplication.DbEntities;

namespace Coffee.Repositories
{
    public class UserRepository : DbRepository<User>, IUserRepository
    {
        public UserRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
