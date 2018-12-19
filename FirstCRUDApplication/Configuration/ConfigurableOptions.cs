using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Configuration
{
    public class ConfigurableOptions : IConfigurableOptions
    {
        public string DbConnection { get; }

        public ConfigurableOptions(string dbConnection)
        {
            DbConnection = dbConnection;
        }
    }
}
