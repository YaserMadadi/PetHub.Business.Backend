

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

public static class ProviderService_Action
{
	
    public static async Task<DataResult<ProviderService>> SaveAttached(this ProviderService providerService, UserCredit userCredit)
    {
        var permissionType = providerService.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(providerService.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ProviderService>(-1, "You don't have Save Permission for ''ProviderService''", providerService);

        return await providerService.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ProviderService>> SaveAttached(this ProviderService providerService, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProviderService_Service providerServiceService = new ProviderService_Service();

        var result = await providerServiceService.Save(providerService, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<ProviderService>(providerService);

        transaction.Commit();

        result = await providerServiceService.RetrieveById(result.Id, ProviderService.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ProviderService>> SaveCollection(this List<ProviderService> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ProviderService> result = new SuccessfulDataResult<ProviderService>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
