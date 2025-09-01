using EssentialCore.DataAccess;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Serializer;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Security.Service
{
    public class UserService : IUserService
    {
        public async Task<DataResult<UserCredit>> RetrieveByUserName(string userName)
        {
            var dataResult = await UserClass.CreateCommand("[Core].[User.RetrieveByUserName]",
                                                       new SqlParameter("@UserName", userName))
                                                            .ExecuteDataResult();

            var userCredit = dataResult.Data.Deserialize<UserCredit[]>(JsonType.Collection);

            if (userCredit == null ||
                userCredit[0].Impersonation_Id <= 0)
            {
                return new ErrorDataResult<UserCredit>(-1, "User not found!", userCredit[0]);
            }

            return new SuccessfulDataResult<UserCredit>(userCredit[0]);
        }
    }
}
