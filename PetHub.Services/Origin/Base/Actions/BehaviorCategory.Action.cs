

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

public static class BehaviorCategory_Action
{
	
    public static async Task<DataResult<BehaviorCategory>> SaveAttached(this BehaviorCategory behaviorCategory, UserCredit userCredit)
    {
        var permissionType = behaviorCategory.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(behaviorCategory.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<BehaviorCategory>(-1, "You don't have Save Permission for ''BehaviorCategory''", behaviorCategory);

        return await behaviorCategory.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<BehaviorCategory>> SaveAttached(this BehaviorCategory behaviorCategory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IBehaviorCategory_Service behaviorCategoryService = new BehaviorCategory_Service();

        var result = await behaviorCategoryService.Save(behaviorCategory, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<BehaviorCategory>(behaviorCategory);

        transaction.Commit();

        result = await behaviorCategoryService.RetrieveById(result.Id, BehaviorCategory.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<BehaviorCategory>> SaveCollection(this List<BehaviorCategory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<BehaviorCategory> result = new SuccessfulDataResult<BehaviorCategory>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
