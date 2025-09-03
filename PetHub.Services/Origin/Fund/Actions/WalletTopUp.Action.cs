

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

public static class WalletTopUp_Action
{
	
    public static async Task<DataResult<WalletTopUp>> SaveAttached(this WalletTopUp walletTopUp, UserCredit userCredit)
    {
        var permissionType = walletTopUp.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(walletTopUp.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<WalletTopUp>(-1, "You don't have Save Permission for ''WalletTopUp''", walletTopUp);

        return await walletTopUp.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<WalletTopUp>> SaveAttached(this WalletTopUp walletTopUp, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IWalletTopUp_Service walletTopUpService = new WalletTopUp_Service();

        var result = await walletTopUpService.Save(walletTopUp, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<WalletTopUp>(walletTopUp);

        transaction.Commit();

        result = await walletTopUpService.RetrieveById(result.Id, WalletTopUp.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<WalletTopUp>> SaveCollection(this List<WalletTopUp> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<WalletTopUp> result = new SuccessfulDataResult<WalletTopUp>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
