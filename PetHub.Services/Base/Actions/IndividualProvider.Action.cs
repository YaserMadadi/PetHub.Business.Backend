

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

public static class IndividualProvider_Action
{
	
    public static async Task<DataResult<IndividualProvider>> SaveAttached(this IndividualProvider individualProvider, UserCredit userCredit)
    {
        var permissionType = individualProvider.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(individualProvider.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<IndividualProvider>(-1, "You don't have Save Permission for ''IndividualProvider''", individualProvider);

        return await individualProvider.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<IndividualProvider>> SaveAttached(this IndividualProvider individualProvider, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IIndividualProvider_Service individualProviderService = new IndividualProvider_Service();

        var result = await individualProviderService.Save(individualProvider, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<IndividualProvider>(individualProvider);

        transaction.Commit();

        result = await individualProviderService.RetrieveById(result.Id, IndividualProvider.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<IndividualProvider>> SaveCollection(this List<IndividualProvider> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<IndividualProvider> result = new SuccessfulDataResult<IndividualProvider>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
