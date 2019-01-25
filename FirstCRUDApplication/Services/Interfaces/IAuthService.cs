using Coffee.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Services.Interfaces
{
    public interface IAuthService
    {
        TokenModelResponse RefreshToken(string RefreshToken);
        TokenModelResponse TokenWeb(string email,string password);
        TokenModelResponse TokenMobile(string phone, string password);
        void Registration(string phone);
        void ConfirmRegister(string phone);
        void Password(string phone);
    }
}
