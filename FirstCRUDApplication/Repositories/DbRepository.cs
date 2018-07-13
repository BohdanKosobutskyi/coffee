using FirstCRUDApplication.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coffee.Repositories
{
    public class DbRepository<TEntity> : IDbRepository<TEntity>
        where TEntity : class
    {
        private CoffeeContext _context;

        public DbRepository(CoffeeContext context)
        {
            _context = context;
        }
        
        public IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }

        public TEntity FindById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Create(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
            _context.SaveChanges();
        }
    }
}
