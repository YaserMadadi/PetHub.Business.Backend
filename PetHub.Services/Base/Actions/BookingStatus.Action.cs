

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

public static class BookingStatus_Action
{
	
    public static async Task<DataResult<BookingStatus>> SaveAttached(this BookingStatus bookingStatus, UserCredit userCredit)
    {
        var permissionType = bookingStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(bookingStatus.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<BookingStatus>(-1, "You don't have Save Permission for ''BookingStatus''", bookingStatus);

        return await bookingStatus.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<BookingStatus>> SaveAttached(this BookingStatus bookingStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IBookingStatus_Service bookingStatusService = new BookingStatus_Service();

        var result = await bookingStatusService.Save(bookingStatus, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<BookingStatus>(bookingStatus);

        transaction.Commit();

        result = await bookingStatusService.RetrieveById(result.Id, BookingStatus.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<BookingStatus>> SaveCollection(this List<BookingStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<BookingStatus> result = new SuccessfulDataResult<BookingStatus>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
