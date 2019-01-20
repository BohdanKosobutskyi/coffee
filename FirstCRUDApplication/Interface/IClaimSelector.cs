using Microsoft.AspNetCore.Http;

namespace Coffee.Interface
{
    public interface IClaimSelector
    {
        long GetId(HttpContext context);
    }
}
