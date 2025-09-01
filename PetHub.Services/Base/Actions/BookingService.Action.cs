

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

public static class BookingService_Action
{
	
    public static async Task<DataResult<BookingService>> SaveAttached(this BookingService bookingService, UserCredit userCredit)
    {
        var permissionType = bookingService.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(bookingService.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<BookingService>(-1, "You don't have Save Permission for ''BookingService''", bookingService);

        return await bookingService.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<BookingService>> SaveAttached(this BookingService bookingService, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IBookingService_Service bookingServiceService = new BookingService_Service();

        var result = await bookingServiceService.Save(bookingService, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<BookingService>(bookingService);

        transaction.Commit();

        result = await bookingServiceService.RetrieveById(result.Id, BookingService.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<BookingService>> SaveCollection(this List<BookingService> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<BookingService> result = new SuccessfulDataResult<BookingService>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
