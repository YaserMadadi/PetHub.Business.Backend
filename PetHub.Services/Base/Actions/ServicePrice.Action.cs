

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

public static class ServicePrice_Action
{
	
    public static async Task<DataResult<ServicePrice>> SaveAttached(this ServicePrice servicePrice, UserCredit userCredit)
    {
        var permissionType = servicePrice.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(servicePrice.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ServicePrice>(-1, "You don't have Save Permission for ''ServicePrice''", servicePrice);

        return await servicePrice.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ServicePrice>> SaveAttached(this ServicePrice servicePrice, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IServicePrice_Service servicePriceService = new ServicePrice_Service();

        var result = await servicePriceService.Save(servicePrice, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ServicePrice>(servicePrice);

        transaction.Commit();

        result = await servicePriceService.RetrieveById(result.Id, ServicePrice.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ServicePrice>> SaveCollection(this List<ServicePrice> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ServicePrice> result = new SuccessfulDataResult<ServicePrice>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
