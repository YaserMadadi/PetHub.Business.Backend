

using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using PetHub.Entities.Fund;
using PetHub.Services.Fund.Abstract;


namespace PetHub.Services.Fund.Actions;

public static class PaymentMethod_Action
{
	
    public static async Task<DataResult<PaymentMethod>> SaveAttached(this PaymentMethod paymentMethod, UserCredit userCredit)
    {
        var permissionType = paymentMethod.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(paymentMethod.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<PaymentMethod>(-1, "You don't have Save Permission for ''PaymentMethod''", paymentMethod);

        return await paymentMethod.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<PaymentMethod>> SaveAttached(this PaymentMethod paymentMethod, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IPaymentMethod_Service paymentMethodService = new PaymentMethod_Service();

        var result = await paymentMethodService.Save(paymentMethod, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<PaymentMethod>(paymentMethod);

        transaction.Commit();

        result = await paymentMethodService.RetrieveById(result.Id, PaymentMethod.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<PaymentMethod>> SaveCollection(this List<PaymentMethod> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<PaymentMethod> result = new SuccessfulDataResult<PaymentMethod>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
