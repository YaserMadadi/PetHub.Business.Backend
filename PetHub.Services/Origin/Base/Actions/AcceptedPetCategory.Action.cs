

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

public static class AcceptedPetCategory_Action
{
	
    public static async Task<DataResult<AcceptedPetCategory>> SaveAttached(this AcceptedPetCategory acceptedPetCategory, UserCredit userCredit)
    {
        var permissionType = acceptedPetCategory.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(acceptedPetCategory.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<AcceptedPetCategory>(-1, "You don't have Save Permission for ''AcceptedPetCategory''", acceptedPetCategory);

        return await acceptedPetCategory.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<AcceptedPetCategory>> SaveAttached(this AcceptedPetCategory acceptedPetCategory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IAcceptedPetCategory_Service acceptedPetCategoryService = new AcceptedPetCategory_Service();

        var result = await acceptedPetCategoryService.Save(acceptedPetCategory, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<AcceptedPetCategory>(acceptedPetCategory);

        transaction.Commit();

        result = await acceptedPetCategoryService.RetrieveById(result.Id, AcceptedPetCategory.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<AcceptedPetCategory>> SaveCollection(this List<AcceptedPetCategory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<AcceptedPetCategory> result = new SuccessfulDataResult<AcceptedPetCategory>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
