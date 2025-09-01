

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

public static class BookingTransaction_Action
{
	
    public static async Task<DataResult<BookingTransaction>> SaveAttached(this BookingTransaction bookingTransaction, UserCredit userCredit)
    {
        var permissionType = bookingTransaction.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(bookingTransaction.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<BookingTransaction>(-1, "You don't have Save Permission for ''BookingTransaction''", bookingTransaction);

        return await bookingTransaction.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<BookingTransaction>> SaveAttached(this BookingTransaction bookingTransaction, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IBookingTransaction_Service bookingTransactionService = new BookingTransaction_Service();

        var result = await bookingTransactionService.Save(bookingTransaction, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<BookingTransaction>(bookingTransaction);

        transaction.Commit();

        result = await bookingTransactionService.RetrieveById(result.Id, BookingTransaction.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<BookingTransaction>> SaveCollection(this List<BookingTransaction> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<BookingTransaction> result = new SuccessfulDataResult<BookingTransaction>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
