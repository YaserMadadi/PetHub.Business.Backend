

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

public static class PetMedicalCondition_Action
{
	
    public static async Task<DataResult<PetMedicalCondition>> SaveAttached(this PetMedicalCondition petMedicalCondition, UserCredit userCredit)
    {
        var permissionType = petMedicalCondition.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(petMedicalCondition.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<PetMedicalCondition>(-1, "You don't have Save Permission for ''PetMedicalCondition''", petMedicalCondition);

        return await petMedicalCondition.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<PetMedicalCondition>> SaveAttached(this PetMedicalCondition petMedicalCondition, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IPetMedicalCondition_Service petMedicalConditionService = new PetMedicalCondition_Service();

        var result = await petMedicalConditionService.Save(petMedicalCondition, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<PetMedicalCondition>(petMedicalCondition);

        transaction.Commit();

        result = await petMedicalConditionService.RetrieveById(result.Id, PetMedicalCondition.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<PetMedicalCondition>> SaveCollection(this List<PetMedicalCondition> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<PetMedicalCondition> result = new SuccessfulDataResult<PetMedicalCondition>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
