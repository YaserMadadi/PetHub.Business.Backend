

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


namespace PetHub.Services.Base.Actions;

public static class Client_Action
{
	
    public static async Task<DataResult<Client>> SaveAttached(this Client client, UserCredit userCredit)
    {
        var permissionType = client.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(client.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Client>(-1, "You don't have Save Permission for ''Client''", client);

        return await client.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Client>> SaveAttached(this Client client, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IClient_Service clientService = new Client_Service();

        var result = await clientService.Save(client, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Client>(client);

        transaction.Commit();

        result = await clientService.RetrieveById(result.Id, Client.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Client>> SaveCollection(this List<Client> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Client> result = new SuccessfulDataResult<Client>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
