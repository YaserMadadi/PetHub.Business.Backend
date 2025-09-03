

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

public static class PetCategory_Action
{
	
    public static async Task<DataResult<PetCategory>> SaveAttached(this PetCategory petCategory, UserCredit userCredit)
    {
        var permissionType = petCategory.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(petCategory.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<PetCategory>(-1, "You don't have Save Permission for ''PetCategory''", petCategory);

        return await petCategory.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<PetCategory>> SaveAttached(this PetCategory petCategory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IPetCategory_Service petCategoryService = new PetCategory_Service();

        var result = await petCategoryService.Save(petCategory, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<PetCategory>(petCategory);

        transaction.Commit();

        result = await petCategoryService.RetrieveById(result.Id, PetCategory.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<PetCategory>> SaveCollection(this List<PetCategory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<PetCategory> result = new SuccessfulDataResult<PetCategory>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
