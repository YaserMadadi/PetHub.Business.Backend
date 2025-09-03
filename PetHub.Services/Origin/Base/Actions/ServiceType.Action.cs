

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

public static class ServiceType_Action
{
	
    public static async Task<DataResult<ServiceType>> SaveAttached(this ServiceType serviceType, UserCredit userCredit)
    {
        var permissionType = serviceType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(serviceType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ServiceType>(-1, "You don't have Save Permission for ''ServiceType''", serviceType);

        return await serviceType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ServiceType>> SaveAttached(this ServiceType serviceType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IServiceType_Service serviceTypeService = new ServiceType_Service();

        var result = await serviceTypeService.Save(serviceType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<ServiceType>(serviceType);

        transaction.Commit();

        result = await serviceTypeService.RetrieveById(result.Id, ServiceType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ServiceType>> SaveCollection(this List<ServiceType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ServiceType> result = new SuccessfulDataResult<ServiceType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
