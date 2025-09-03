

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

public static class CertificationType_Action
{
	
    public static async Task<DataResult<CertificationType>> SaveAttached(this CertificationType certificationType, UserCredit userCredit)
    {
        var permissionType = certificationType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(certificationType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<CertificationType>(-1, "You don't have Save Permission for ''CertificationType''", certificationType);

        return await certificationType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<CertificationType>> SaveAttached(this CertificationType certificationType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ICertificationType_Service certificationTypeService = new CertificationType_Service();

        var result = await certificationTypeService.Save(certificationType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<CertificationType>(certificationType);

        transaction.Commit();

        result = await certificationTypeService.RetrieveById(result.Id, CertificationType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<CertificationType>> SaveCollection(this List<CertificationType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<CertificationType> result = new SuccessfulDataResult<CertificationType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
