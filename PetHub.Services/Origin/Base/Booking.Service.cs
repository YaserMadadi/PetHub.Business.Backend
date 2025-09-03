
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Base;
using PetHub.Services.Base.Actions;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Fund;

namespace PetHub.Services.Base;

public class Booking_Service : Service<Booking>, IBooking_Service
{
    public Booking_Service() : base()
    {
    }

    public override async Task<DataResult<Booking>> SaveAttached(Booking booking, UserCredit userCredit)
    {
        return await booking.SaveAttached(userCredit);
    }

    public DataResult<List<BookingService>> CollectionOfBookingService(int booking_Id, BookingService bookingService, UserCredit userCredit)
    {
        var procedureName = "[Base].[Booking.CollectionOfBookingService]";

        return this.CollectionOf<BookingService>(procedureName, 
                                                        new SqlParameter("@Id", booking_Id), 
                                                        new SqlParameter("@jsonValue", bookingService.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<BookingTransaction>> CollectionOfBookingTransaction(int booking_Id, BookingTransaction bookingTransaction, UserCredit userCredit)
    {
        var procedureName = "[Base].[Booking.CollectionOfBookingTransaction]";

        return this.CollectionOf<BookingTransaction>(procedureName, 
                                                        new SqlParameter("@Id", booking_Id), 
                                                        new SqlParameter("@jsonValue", bookingTransaction.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
