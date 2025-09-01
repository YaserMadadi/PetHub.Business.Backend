

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

public static class VerificationStatus_Action
{
	
    public static async Task<DataResult<VerificationStatus>> SaveAttached(this VerificationStatus verificationStatus, UserCredit userCredit)
    {
        var permissionType = verificationStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(verificationStatus.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<VerificationStatus>(-1, "You don't have Save Permission for ''VerificationStatus''", verificationStatus);

        return await verificationStatus.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<VerificationStatus>> SaveAttached(this VerificationStatus verificationStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IVerificationStatus_Service verificationStatusService = new VerificationStatus_Service();

        var result = await verificationStatusService.Save(verificationStatus, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<VerificationStatus>(verificationStatus);

        transaction.Commit();

        result = await verificationStatusService.RetrieveById(result.Id, VerificationStatus.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<VerificationStatus>> SaveCollection(this List<VerificationStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<VerificationStatus> result = new SuccessfulDataResult<VerificationStatus>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
