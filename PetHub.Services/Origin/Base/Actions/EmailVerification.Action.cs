

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

public static class EmailVerification_Action
{
	
    public static async Task<DataResult<EmailVerification>> SaveAttached(this EmailVerification emailVerification, UserCredit userCredit)
    {
        var permissionType = emailVerification.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(emailVerification.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<EmailVerification>(-1, "You don't have Save Permission for ''EmailVerification''", emailVerification);

        return await emailVerification.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<EmailVerification>> SaveAttached(this EmailVerification emailVerification, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IEmailVerification_Service emailVerificationService = new EmailVerification_Service();

        var result = await emailVerificationService.Save(emailVerification, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<EmailVerification>(emailVerification);

        transaction.Commit();

        result = await emailVerificationService.RetrieveById(result.Id, EmailVerification.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<EmailVerification>> SaveCollection(this List<EmailVerification> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<EmailVerification> result = new SuccessfulDataResult<EmailVerification>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
