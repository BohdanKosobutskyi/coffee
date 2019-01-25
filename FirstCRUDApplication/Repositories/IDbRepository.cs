using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coffee.Repositories
{
    public interface IDbRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(long id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
