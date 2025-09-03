

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

public static class ProviderWallet_Action
{
	
    public static async Task<DataResult<ProviderWallet>> SaveAttached(this ProviderWallet providerWallet, UserCredit userCredit)
    {
        var permissionType = providerWallet.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(providerWallet.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ProviderWallet>(-1, "You don't have Save Permission for ''ProviderWallet''", providerWallet);

        return await providerWallet.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ProviderWallet>> SaveAttached(this ProviderWallet providerWallet, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProviderWallet_Service providerWalletService = new ProviderWallet_Service();

        var result = await providerWalletService.Save(providerWallet, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<ProviderWallet>(providerWallet);

        transaction.Commit();

        result = await providerWalletService.RetrieveById(result.Id, ProviderWallet.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ProviderWallet>> SaveCollection(this List<ProviderWallet> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ProviderWallet> result = new SuccessfulDataResult<ProviderWallet>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
