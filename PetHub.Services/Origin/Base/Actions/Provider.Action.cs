

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
using PetHub.Services.Fund.Actions;
using PetHub.Entities.Fund;
using PetHub.Services.Fund.Actions;
using PetHub.Entities.Fund;


namespace PetHub.Services.Base.Actions;

public static class Provider_Action
{
	
    public static async Task<DataResult<Provider>> SaveAttached(this Provider provider, UserCredit userCredit)
    {
        var permissionType = provider.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(provider.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Provider>(-1, "You don't have Save Permission for ''Provider''", provider);

        return await provider.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Provider>> SaveAttached(this Provider provider, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProvider_Service providerService = new Provider_Service();

        var result = await providerService.Save(provider, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Provider>(provider);

        transaction.Commit();

        result = await providerService.RetrieveById(result.Id, Provider.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Provider>> SaveCollection(this List<Provider> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Provider> result = new SuccessfulDataResult<Provider>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
