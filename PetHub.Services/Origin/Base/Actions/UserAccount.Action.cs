

using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using PetHub.Entities.Base;
using PetHub.Services.Base.Abstract;
using PetHub.Services.Admin.Actions;
using PetHub.Entities.Admin;
using PetHub.Services.Admin.Actions;
using PetHub.Entities.Admin;


namespace PetHub.Services.Base.Actions;

public static class UserAccount_Action
{
	
    public static async Task<DataResult<UserAccount>> SaveAttached(this UserAccount userAccount, UserCredit userCredit)
    {
        var permissionType = userAccount.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(userAccount.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<UserAccount>(-1, "You don't have Save Permission for ''UserAccount''", userAccount);

        return await userAccount.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<UserAccount>> SaveAttached(this UserAccount userAccount, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IUserAccount_Service userAccountService = new UserAccount_Service();

        var result = await userAccountService.Save(userAccount, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<UserAccount>(userAccount);

        transaction.Commit();

        result = await userAccountService.RetrieveById(result.Id, UserAccount.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<UserAccount>> SaveCollection(this List<UserAccount> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<UserAccount> result = new SuccessfulDataResult<UserAccount>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
