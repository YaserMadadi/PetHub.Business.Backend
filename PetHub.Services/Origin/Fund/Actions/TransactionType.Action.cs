

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

public static class TransactionType_Action
{
	
    public static async Task<DataResult<TransactionType>> SaveAttached(this TransactionType transactionType, UserCredit userCredit)
    {
        var permissionType = transactionType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(transactionType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<TransactionType>(-1, "You don't have Save Permission for ''TransactionType''", transactionType);

        return await transactionType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<TransactionType>> SaveAttached(this TransactionType transactionType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ITransactionType_Service transactionTypeService = new TransactionType_Service();

        var result = await transactionTypeService.Save(transactionType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<TransactionType>(transactionType);

        transaction.Commit();

        result = await transactionTypeService.RetrieveById(result.Id, TransactionType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<TransactionType>> SaveCollection(this List<TransactionType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<TransactionType> result = new SuccessfulDataResult<TransactionType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
