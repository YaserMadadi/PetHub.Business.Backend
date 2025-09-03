

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

public static class InsuranceType_Action
{
	
    public static async Task<DataResult<InsuranceType>> SaveAttached(this InsuranceType insuranceType, UserCredit userCredit)
    {
        var permissionType = insuranceType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(insuranceType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<InsuranceType>(-1, "You don't have Save Permission for ''InsuranceType''", insuranceType);

        return await insuranceType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<InsuranceType>> SaveAttached(this InsuranceType insuranceType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IInsuranceType_Service insuranceTypeService = new InsuranceType_Service();

        var result = await insuranceTypeService.Save(insuranceType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<InsuranceType>(insuranceType);

        transaction.Commit();

        result = await insuranceTypeService.RetrieveById(result.Id, InsuranceType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<InsuranceType>> SaveCollection(this List<InsuranceType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<InsuranceType> result = new SuccessfulDataResult<InsuranceType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
