using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Security.Service
{
    public interface IAuthService
    {
        public Task<IDataResult<AccessToken>> Login(LoginUser loginUser);

        public Task<IDataResult<UserCredit>> CheckInDataBase(string userName);

        //public IDataResult<UserCredit> Register(RegisterUser registerUser);
    }
}
