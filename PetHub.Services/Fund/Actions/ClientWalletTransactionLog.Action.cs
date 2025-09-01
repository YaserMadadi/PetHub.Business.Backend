

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

public static class ClientWalletTransactionLog_Action
{
	
    public static async Task<DataResult<ClientWalletTransactionLog>> SaveAttached(this ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit)
    {
        var permissionType = clientWalletTransactionLog.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(clientWalletTransactionLog.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ClientWalletTransactionLog>(-1, "You don't have Save Permission for ''ClientWalletTransactionLog''", clientWalletTransactionLog);

        return await clientWalletTransactionLog.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ClientWalletTransactionLog>> SaveAttached(this ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IClientWalletTransactionLog_Service clientWalletTransactionLogService = new ClientWalletTransactionLog_Service();

        var result = await clientWalletTransactionLogService.Save(clientWalletTransactionLog, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ClientWalletTransactionLog>(clientWalletTransactionLog);

        transaction.Commit();

        result = await clientWalletTransactionLogService.RetrieveById(result.Id, ClientWalletTransactionLog.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ClientWalletTransactionLog>> SaveCollection(this List<ClientWalletTransactionLog> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ClientWalletTransactionLog> result = new SuccessfulDataResult<ClientWalletTransactionLog>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
