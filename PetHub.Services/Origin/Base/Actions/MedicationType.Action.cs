

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

public static class MedicationType_Action
{
	
    public static async Task<DataResult<MedicationType>> SaveAttached(this MedicationType medicationType, UserCredit userCredit)
    {
        var permissionType = medicationType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(medicationType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<MedicationType>(-1, "You don't have Save Permission for ''MedicationType''", medicationType);

        return await medicationType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<MedicationType>> SaveAttached(this MedicationType medicationType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IMedicationType_Service medicationTypeService = new MedicationType_Service();

        var result = await medicationTypeService.Save(medicationType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<MedicationType>(medicationType);

        transaction.Commit();

        result = await medicationTypeService.RetrieveById(result.Id, MedicationType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<MedicationType>> SaveCollection(this List<MedicationType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<MedicationType> result = new SuccessfulDataResult<MedicationType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
