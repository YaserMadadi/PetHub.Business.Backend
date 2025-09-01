

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

public static class PhoneNumberVerification_Action
{
	
    public static async Task<DataResult<PhoneNumberVerification>> SaveAttached(this PhoneNumberVerification phoneNumberVerification, UserCredit userCredit)
    {
        var permissionType = phoneNumberVerification.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(phoneNumberVerification.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<PhoneNumberVerification>(-1, "You don't have Save Permission for ''PhoneNumberVerification''", phoneNumberVerification);

        return await phoneNumberVerification.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<PhoneNumberVerification>> SaveAttached(this PhoneNumberVerification phoneNumberVerification, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IPhoneNumberVerification_Service phoneNumberVerificationService = new PhoneNumberVerification_Service();

        var result = await phoneNumberVerificationService.Save(phoneNumberVerification, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<PhoneNumberVerification>(phoneNumberVerification);

        transaction.Commit();

        result = await phoneNumberVerificationService.RetrieveById(result.Id, PhoneNumberVerification.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<PhoneNumberVerification>> SaveCollection(this List<PhoneNumberVerification> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<PhoneNumberVerification> result = new SuccessfulDataResult<PhoneNumberVerification>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
