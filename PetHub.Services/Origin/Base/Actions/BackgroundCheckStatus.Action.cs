

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

public static class BackgroundCheckStatus_Action
{
	
    public static async Task<DataResult<BackgroundCheckStatus>> SaveAttached(this BackgroundCheckStatus backgroundCheckStatus, UserCredit userCredit)
    {
        var permissionType = backgroundCheckStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(backgroundCheckStatus.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<BackgroundCheckStatus>(-1, "You don't have Save Permission for ''BackgroundCheckStatus''", backgroundCheckStatus);

        return await backgroundCheckStatus.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<BackgroundCheckStatus>> SaveAttached(this BackgroundCheckStatus backgroundCheckStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IBackgroundCheckStatus_Service backgroundCheckStatusService = new BackgroundCheckStatus_Service();

        var result = await backgroundCheckStatusService.Save(backgroundCheckStatus, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<BackgroundCheckStatus>(backgroundCheckStatus);

        transaction.Commit();

        result = await backgroundCheckStatusService.RetrieveById(result.Id, BackgroundCheckStatus.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<BackgroundCheckStatus>> SaveCollection(this List<BackgroundCheckStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<BackgroundCheckStatus> result = new SuccessfulDataResult<BackgroundCheckStatus>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
