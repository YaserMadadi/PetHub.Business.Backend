

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

public static class PriceScope_Action
{
	
    public static async Task<DataResult<PriceScope>> SaveAttached(this PriceScope priceScope, UserCredit userCredit)
    {
        var permissionType = priceScope.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(priceScope.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<PriceScope>(-1, "You don't have Save Permission for ''PriceScope''", priceScope);

        return await priceScope.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<PriceScope>> SaveAttached(this PriceScope priceScope, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IPriceScope_Service priceScopeService = new PriceScope_Service();

        var result = await priceScopeService.Save(priceScope, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<PriceScope>(priceScope);

        transaction.Commit();

        result = await priceScopeService.RetrieveById(result.Id, PriceScope.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<PriceScope>> SaveCollection(this List<PriceScope> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<PriceScope> result = new SuccessfulDataResult<PriceScope>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
