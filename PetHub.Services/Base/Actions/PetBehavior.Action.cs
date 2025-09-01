

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

public static class PetBehavior_Action
{
	
    public static async Task<DataResult<PetBehavior>> SaveAttached(this PetBehavior petBehavior, UserCredit userCredit)
    {
        var permissionType = petBehavior.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(petBehavior.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<PetBehavior>(-1, "You don't have Save Permission for ''PetBehavior''", petBehavior);

        return await petBehavior.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<PetBehavior>> SaveAttached(this PetBehavior petBehavior, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IPetBehavior_Service petBehaviorService = new PetBehavior_Service();

        var result = await petBehaviorService.Save(petBehavior, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<PetBehavior>(petBehavior);

        transaction.Commit();

        result = await petBehaviorService.RetrieveById(result.Id, PetBehavior.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<PetBehavior>> SaveCollection(this List<PetBehavior> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<PetBehavior> result = new SuccessfulDataResult<PetBehavior>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
