

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

public static class WeightUnit_Action
{
	
    public static async Task<DataResult<WeightUnit>> SaveAttached(this WeightUnit weightUnit, UserCredit userCredit)
    {
        var permissionType = weightUnit.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(weightUnit.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<WeightUnit>(-1, "You don't have Save Permission for ''WeightUnit''", weightUnit);

        return await weightUnit.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<WeightUnit>> SaveAttached(this WeightUnit weightUnit, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IWeightUnit_Service weightUnitService = new WeightUnit_Service();

        var result = await weightUnitService.Save(weightUnit, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<WeightUnit>(weightUnit);

        transaction.Commit();

        result = await weightUnitService.RetrieveById(result.Id, WeightUnit.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<WeightUnit>> SaveCollection(this List<WeightUnit> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<WeightUnit> result = new SuccessfulDataResult<WeightUnit>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
