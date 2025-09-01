
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Base;
using PetHub.Services.Base.Actions;
using PetHub.Services.Base.Abstract;

namespace PetHub.Services.Base;

public class AccountStatus_Service : Service<AccountStatus>, IAccountStatus_Service
{
    public AccountStatus_Service() : base()
    {
    }

    public override async Task<DataResult<AccountStatus>> SaveAttached(AccountStatus accountStatus, UserCredit userCredit)
    {
        return await accountStatus.SaveAttached(userCredit);
    }

    public DataResult<List<UserAccount>> CollectionOfUserAccount(int accountStatus_Id, UserAccount userAccount, UserCredit userCredit)
    {
        var procedureName = "[Base].[AccountStatus.CollectionOfUserAccount]";

        return this.CollectionOf<UserAccount>(procedureName, 
                                                        new SqlParameter("@Id", accountStatus_Id), 
                                                        new SqlParameter("@jsonValue", userAccount.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
