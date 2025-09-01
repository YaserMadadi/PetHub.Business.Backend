

using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using PetHub.Entities.Infra;
using PetHub.Services.Infra.Abstract;


namespace PetHub.Services.Infra.Actions;

public static class CheckConstraint_Action
{
	
    public static async Task<DataResult<CheckConstraint>> SaveAttached(this CheckConstraint checkConstraint, UserCredit userCredit)
    {
        var permissionType = checkConstraint.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(checkConstraint.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<CheckConstraint>(-1, "You don't have Save Permission for ''CheckConstraint''", checkConstraint);

        return await checkConstraint.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<CheckConstraint>> SaveAttached(this CheckConstraint checkConstraint, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ICheckConstraint_Service checkConstraintService = new CheckConstraint_Service();

        var result = await checkConstraintService.Save(checkConstraint, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<CheckConstraint>(checkConstraint);

        transaction.Commit();

        result = await checkConstraintService.RetrieveById(result.Id, CheckConstraint.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<CheckConstraint>> SaveCollection(this List<CheckConstraint> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<CheckConstraint> result = new SuccessfulDataResult<CheckConstraint>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
