

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
using PetHub.Services.Fund.Actions;
using PetHub.Entities.Fund;


namespace PetHub.Services.Base.Actions;

public static class EnterpriseProvider_Action
{
	
    public static async Task<DataResult<EnterpriseProvider>> SaveAttached(this EnterpriseProvider enterpriseProvider, UserCredit userCredit)
    {
        var permissionType = enterpriseProvider.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(enterpriseProvider.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<EnterpriseProvider>(-1, "You don't have Save Permission for ''EnterpriseProvider''", enterpriseProvider);

        return await enterpriseProvider.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<EnterpriseProvider>> SaveAttached(this EnterpriseProvider enterpriseProvider, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IEnterpriseProvider_Service enterpriseProviderService = new EnterpriseProvider_Service();

        var result = await enterpriseProviderService.Save(enterpriseProvider, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<EnterpriseProvider>(enterpriseProvider);

        transaction.Commit();

        result = await enterpriseProviderService.RetrieveById(result.Id, EnterpriseProvider.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<EnterpriseProvider>> SaveCollection(this List<EnterpriseProvider> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<EnterpriseProvider> result = new SuccessfulDataResult<EnterpriseProvider>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
