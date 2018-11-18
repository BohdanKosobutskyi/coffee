using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Services.Interfaces
{
    public interface ISellerService
    {
        void AddPoints(long userId, long points, long seellerId);
    }
}
