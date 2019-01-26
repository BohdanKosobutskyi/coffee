using Coffee.DbEntities;
using Coffee.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Repositories
{
    public class PostRepository : DbRepository<Post>, IPostRepository
    {
        public PostRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
