

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

public static class ProviderCertification_Action
{
	
    public static async Task<DataResult<ProviderCertification>> SaveAttached(this ProviderCertification providerCertification, UserCredit userCredit)
    {
        var permissionType = providerCertification.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(providerCertification.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ProviderCertification>(-1, "You don't have Save Permission for ''ProviderCertification''", providerCertification);

        return await providerCertification.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ProviderCertification>> SaveAttached(this ProviderCertification providerCertification, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IProviderCertification_Service providerCertificationService = new ProviderCertification_Service();

        var result = await providerCertificationService.Save(providerCertification, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ProviderCertification>(providerCertification);

        transaction.Commit();

        result = await providerCertificationService.RetrieveById(result.Id, ProviderCertification.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ProviderCertification>> SaveCollection(this List<ProviderCertification> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ProviderCertification> result = new SuccessfulDataResult<ProviderCertification>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
