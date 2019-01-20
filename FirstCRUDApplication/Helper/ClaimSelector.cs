using Coffee.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Coffee.Helper
{
    public class ClaimSelector : IClaimSelector
    {
        public long GetId(HttpContext context)
        {
            return long.Parse(context.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
        }
    }
}
