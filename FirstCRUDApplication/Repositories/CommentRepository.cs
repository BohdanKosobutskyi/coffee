using Coffee.DbEntities;
using Coffee.Repositories.Interfaces;
using FirstCRUDApplication.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Repositories
{
    public class CommentRepository : DbRepository<Comment>, ICommentRepository
    {
        public CommentRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
