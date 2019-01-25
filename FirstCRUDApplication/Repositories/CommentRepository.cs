using Coffee.DbEntities;
using Coffee.Repositories.Interfaces;
using Coffee.DbEntities;

namespace Coffee.Repositories
{
    public class CommentRepository : DbRepository<Comment>, ICommentRepository
    {
        public CommentRepository(CoffeeContext context) : base(context)
        {

        }
    }
}
