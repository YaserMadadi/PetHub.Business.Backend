

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

public static class ProviderBankAccount_Action
{
	
    public static async Task<DataResult<ProviderBankAccount>> SaveAttached(this ProviderBankAccount providerBankAccount, UserCredit userCredit)
    {
        var permissionType = providerBankAccount.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(providerBankAccount.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ProviderBankAccount>(-1, "You don't have Save Permission for ''ProviderBankAccount''", providerBankAccount);

        return await providerBankAccount.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ProviderBankAccount>> SaveAttached(this ProviderBankAccount providerBankAccount, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProviderBankAccount_Service providerBankAccountService = new ProviderBankAccount_Service();

        var result = await providerBankAccountService.Save(providerBankAccount, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ProviderBankAccount>(providerBankAccount);

        transaction.Commit();

        result = await providerBankAccountService.RetrieveById(result.Id, ProviderBankAccount.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ProviderBankAccount>> SaveCollection(this List<ProviderBankAccount> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ProviderBankAccount> result = new SuccessfulDataResult<ProviderBankAccount>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
