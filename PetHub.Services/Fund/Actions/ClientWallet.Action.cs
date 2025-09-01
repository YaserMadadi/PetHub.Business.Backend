

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

public static class ClientWallet_Action
{
	
    public static async Task<DataResult<ClientWallet>> SaveAttached(this ClientWallet clientWallet, UserCredit userCredit)
    {
        var permissionType = clientWallet.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(clientWallet.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ClientWallet>(-1, "You don't have Save Permission for ''ClientWallet''", clientWallet);

        return await clientWallet.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ClientWallet>> SaveAttached(this ClientWallet clientWallet, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IClientWallet_Service clientWalletService = new ClientWallet_Service();

        var result = await clientWalletService.Save(clientWallet, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<ClientWallet>(clientWallet);

        transaction.Commit();

        result = await clientWalletService.RetrieveById(result.Id, ClientWallet.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ClientWallet>> SaveCollection(this List<ClientWallet> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ClientWallet> result = new SuccessfulDataResult<ClientWallet>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
