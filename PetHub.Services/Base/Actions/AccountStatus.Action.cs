

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


namespace PetHub.Services.Base.Actions;

public static class AccountStatus_Action
{
	
    public static async Task<DataResult<AccountStatus>> SaveAttached(this AccountStatus accountStatus, UserCredit userCredit)
    {
        var permissionType = accountStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(accountStatus.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<AccountStatus>(-1, "You don't have Save Permission for ''AccountStatus''", accountStatus);

        return await accountStatus.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<AccountStatus>> SaveAttached(this AccountStatus accountStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IAccountStatus_Service accountStatusService = new AccountStatus_Service();

        var result = await accountStatusService.Save(accountStatus, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<AccountStatus>(accountStatus);

        transaction.Commit();

        result = await accountStatusService.RetrieveById(result.Id, AccountStatus.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<AccountStatus>> SaveCollection(this List<AccountStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<AccountStatus> result = new SuccessfulDataResult<AccountStatus>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
