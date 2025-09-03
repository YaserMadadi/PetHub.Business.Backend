

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

public static class EnterpriseProviderInsurance_Action
{
	
    public static async Task<DataResult<EnterpriseProviderInsurance>> SaveAttached(this EnterpriseProviderInsurance enterpriseProviderInsurance, UserCredit userCredit)
    {
        var permissionType = enterpriseProviderInsurance.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(enterpriseProviderInsurance.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<EnterpriseProviderInsurance>(-1, "You don't have Save Permission for ''EnterpriseProviderInsurance''", enterpriseProviderInsurance);

        return await enterpriseProviderInsurance.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<EnterpriseProviderInsurance>> SaveAttached(this EnterpriseProviderInsurance enterpriseProviderInsurance, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IEnterpriseProviderInsurance_Service enterpriseProviderInsuranceService = new EnterpriseProviderInsurance_Service();

        var result = await enterpriseProviderInsuranceService.Save(enterpriseProviderInsurance, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<EnterpriseProviderInsurance>(enterpriseProviderInsurance);

        transaction.Commit();

        result = await enterpriseProviderInsuranceService.RetrieveById(result.Id, EnterpriseProviderInsurance.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<EnterpriseProviderInsurance>> SaveCollection(this List<EnterpriseProviderInsurance> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<EnterpriseProviderInsurance> result = new SuccessfulDataResult<EnterpriseProviderInsurance>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
