

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

public static class ProviderConnection_Action
{
	
    public static async Task<DataResult<ProviderConnection>> SaveAttached(this ProviderConnection providerConnection, UserCredit userCredit)
    {
        var permissionType = providerConnection.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(providerConnection.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ProviderConnection>(-1, "You don't have Save Permission for ''ProviderConnection''", providerConnection);

        return await providerConnection.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ProviderConnection>> SaveAttached(this ProviderConnection providerConnection, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProviderConnection_Service providerConnectionService = new ProviderConnection_Service();

        var result = await providerConnectionService.Save(providerConnection, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ProviderConnection>(providerConnection);

        transaction.Commit();

        result = await providerConnectionService.RetrieveById(result.Id, ProviderConnection.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ProviderConnection>> SaveCollection(this List<ProviderConnection> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ProviderConnection> result = new SuccessfulDataResult<ProviderConnection>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
