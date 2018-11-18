using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Contracts
{
    public class TokenModelResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public DateTime expire_time { get; set; }
    }
}
