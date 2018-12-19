using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Configuration
{
    public interface IConfigurableOptions
    {
        string DbConnection { get; }
    }
}
