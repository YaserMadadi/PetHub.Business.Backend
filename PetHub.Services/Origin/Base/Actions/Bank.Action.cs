

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

public static class Bank_Action
{
	
    public static async Task<DataResult<Bank>> SaveAttached(this Bank bank, UserCredit userCredit)
    {
        var permissionType = bank.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(bank.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Bank>(-1, "You don't have Save Permission for ''Bank''", bank);

        return await bank.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Bank>> SaveAttached(this Bank bank, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IBank_Service bankService = new Bank_Service();

        var result = await bankService.Save(bank, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Bank>(bank);

        transaction.Commit();

        result = await bankService.RetrieveById(result.Id, Bank.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Bank>> SaveCollection(this List<Bank> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Bank> result = new SuccessfulDataResult<Bank>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
