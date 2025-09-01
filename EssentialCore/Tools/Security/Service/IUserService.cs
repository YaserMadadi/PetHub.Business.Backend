using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Security.Service
{
    public interface IUserService
    {
        public Task<DataResult<UserCredit>> RetrieveByUserName(string userName);
    }
}
