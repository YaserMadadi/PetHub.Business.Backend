

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

public static class ServiceOrientedWorkTime_Action
{
	
    public static async Task<DataResult<ServiceOrientedWorkTime>> SaveAttached(this ServiceOrientedWorkTime serviceOrientedWorkTime, UserCredit userCredit)
    {
        var permissionType = serviceOrientedWorkTime.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(serviceOrientedWorkTime.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ServiceOrientedWorkTime>(-1, "You don't have Save Permission for ''ServiceOrientedWorkTime''", serviceOrientedWorkTime);

        return await serviceOrientedWorkTime.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ServiceOrientedWorkTime>> SaveAttached(this ServiceOrientedWorkTime serviceOrientedWorkTime, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IServiceOrientedWorkTime_Service serviceOrientedWorkTimeService = new ServiceOrientedWorkTime_Service();

        var result = await serviceOrientedWorkTimeService.Save(serviceOrientedWorkTime, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ServiceOrientedWorkTime>(serviceOrientedWorkTime);

        transaction.Commit();

        result = await serviceOrientedWorkTimeService.RetrieveById(result.Id, ServiceOrientedWorkTime.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ServiceOrientedWorkTime>> SaveCollection(this List<ServiceOrientedWorkTime> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ServiceOrientedWorkTime> result = new SuccessfulDataResult<ServiceOrientedWorkTime>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
