

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
using PetHub.Services.Fund.Actions;
using PetHub.Entities.Fund;


namespace PetHub.Services.Base.Actions;

public static class Booking_Action
{
	
    public static async Task<DataResult<Booking>> SaveAttached(this Booking booking, UserCredit userCredit)
    {
        var permissionType = booking.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(booking.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Booking>(-1, "You don't have Save Permission for ''Booking''", booking);

        return await booking.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Booking>> SaveAttached(this Booking booking, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IBooking_Service bookingService = new Booking_Service();

        var result = await bookingService.Save(booking, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Booking>(booking);

        transaction.Commit();

        result = await bookingService.RetrieveById(result.Id, Booking.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Booking>> SaveCollection(this List<Booking> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Booking> result = new SuccessfulDataResult<Booking>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
