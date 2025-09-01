

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

public static class TransactionStatus_Action
{
	
    public static async Task<DataResult<TransactionStatus>> SaveAttached(this TransactionStatus transactionStatus, UserCredit userCredit)
    {
        var permissionType = transactionStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(transactionStatus.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<TransactionStatus>(-1, "You don't have Save Permission for ''TransactionStatus''", transactionStatus);

        return await transactionStatus.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<TransactionStatus>> SaveAttached(this TransactionStatus transactionStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ITransactionStatus_Service transactionStatusService = new TransactionStatus_Service();

        var result = await transactionStatusService.Save(transactionStatus, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<TransactionStatus>(transactionStatus);

        transaction.Commit();

        result = await transactionStatusService.RetrieveById(result.Id, TransactionStatus.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<TransactionStatus>> SaveCollection(this List<TransactionStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<TransactionStatus> result = new SuccessfulDataResult<TransactionStatus>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
