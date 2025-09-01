

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

public static class DurationUnit_Action
{
	
    public static async Task<DataResult<DurationUnit>> SaveAttached(this DurationUnit durationUnit, UserCredit userCredit)
    {
        var permissionType = durationUnit.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(durationUnit.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<DurationUnit>(-1, "You don't have Save Permission for ''DurationUnit''", durationUnit);

        return await durationUnit.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<DurationUnit>> SaveAttached(this DurationUnit durationUnit, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IDurationUnit_Service durationUnitService = new DurationUnit_Service();

        var result = await durationUnitService.Save(durationUnit, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<DurationUnit>(durationUnit);

        transaction.Commit();

        result = await durationUnitService.RetrieveById(result.Id, DurationUnit.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<DurationUnit>> SaveCollection(this List<DurationUnit> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<DurationUnit> result = new SuccessfulDataResult<DurationUnit>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
