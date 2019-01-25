using System;
using System.Collections.Generic;
using Coffee.DbEntities;
using Coffee.Repositories.Interfaces;
using Coffee.DbEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Coffee.Repositories
{
    public class SellerRepository : DbRepository<Seller>, ISellerRepository
    {
        CoffeeContext _context;

        public SellerRepository(CoffeeContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Seller> Get(Func<Seller,bool> predicate)
        {
            return _context.Set<Seller>().AsNoTracking().Include(item => item.Company).Where(predicate);
        }
    }
}
