

using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using PetHub.Entities.Fund;
using PetHub.Services.Fund.Abstract;


namespace PetHub.Services.Fund.Actions;

public static class ProviderPayOut_Action
{
	
    public static async Task<DataResult<ProviderPayOut>> SaveAttached(this ProviderPayOut providerPayOut, UserCredit userCredit)
    {
        var permissionType = providerPayOut.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(providerPayOut.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ProviderPayOut>(-1, "You don't have Save Permission for ''ProviderPayOut''", providerPayOut);

        return await providerPayOut.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ProviderPayOut>> SaveAttached(this ProviderPayOut providerPayOut, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProviderPayOut_Service providerPayOutService = new ProviderPayOut_Service();

        var result = await providerPayOutService.Save(providerPayOut, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ProviderPayOut>(providerPayOut);

        transaction.Commit();

        result = await providerPayOutService.RetrieveById(result.Id, ProviderPayOut.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ProviderPayOut>> SaveCollection(this List<ProviderPayOut> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ProviderPayOut> result = new SuccessfulDataResult<ProviderPayOut>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
