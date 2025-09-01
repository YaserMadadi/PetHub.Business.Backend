

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

public static class ProviderType_Action
{
	
    public static async Task<DataResult<ProviderType>> SaveAttached(this ProviderType providerType, UserCredit userCredit)
    {
        var permissionType = providerType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(providerType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ProviderType>(-1, "You don't have Save Permission for ''ProviderType''", providerType);

        return await providerType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ProviderType>> SaveAttached(this ProviderType providerType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProviderType_Service providerTypeService = new ProviderType_Service();

        var result = await providerTypeService.Save(providerType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<ProviderType>(providerType);

        transaction.Commit();

        result = await providerTypeService.RetrieveById(result.Id, ProviderType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ProviderType>> SaveCollection(this List<ProviderType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ProviderType> result = new SuccessfulDataResult<ProviderType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
