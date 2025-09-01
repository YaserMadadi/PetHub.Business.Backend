

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

public static class WorkTime_Action
{
	
    public static async Task<DataResult<WorkTime>> SaveAttached(this WorkTime workTime, UserCredit userCredit)
    {
        var permissionType = workTime.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(workTime.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<WorkTime>(-1, "You don't have Save Permission for ''WorkTime''", workTime);

        return await workTime.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<WorkTime>> SaveAttached(this WorkTime workTime, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IWorkTime_Service workTimeService = new WorkTime_Service();

        var result = await workTimeService.Save(workTime, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<WorkTime>(workTime);

        transaction.Commit();

        result = await workTimeService.RetrieveById(result.Id, WorkTime.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<WorkTime>> SaveCollection(this List<WorkTime> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<WorkTime> result = new SuccessfulDataResult<WorkTime>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
