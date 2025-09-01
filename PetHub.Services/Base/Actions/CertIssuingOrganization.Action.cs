

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

public static class CertIssuingOrganization_Action
{
	
    public static async Task<DataResult<CertIssuingOrganization>> SaveAttached(this CertIssuingOrganization certIssuingOrganization, UserCredit userCredit)
    {
        var permissionType = certIssuingOrganization.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(certIssuingOrganization.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<CertIssuingOrganization>(-1, "You don't have Save Permission for ''CertIssuingOrganization''", certIssuingOrganization);

        return await certIssuingOrganization.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<CertIssuingOrganization>> SaveAttached(this CertIssuingOrganization certIssuingOrganization, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ICertIssuingOrganization_Service certIssuingOrganizationService = new CertIssuingOrganization_Service();

        var result = await certIssuingOrganizationService.Save(certIssuingOrganization, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<CertIssuingOrganization>(certIssuingOrganization);

        transaction.Commit();

        result = await certIssuingOrganizationService.RetrieveById(result.Id, CertIssuingOrganization.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<CertIssuingOrganization>> SaveCollection(this List<CertIssuingOrganization> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<CertIssuingOrganization> result = new SuccessfulDataResult<CertIssuingOrganization>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
