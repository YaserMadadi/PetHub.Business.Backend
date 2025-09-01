
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

namespace PetHub.Services.Base;

public class BookingStatus_Service : Service<BookingStatus>, IBookingStatus_Service
{
    public BookingStatus_Service() : base()
    {
    }

    public override async Task<DataResult<BookingStatus>> SaveAttached(BookingStatus bookingStatus, UserCredit userCredit)
    {
        return await bookingStatus.SaveAttached(userCredit);
    }

    public DataResult<List<Booking>> CollectionOfBooking(int bookingStatus_Id, Booking booking, UserCredit userCredit)
    {
        var procedureName = "[Base].[BookingStatus.CollectionOfBooking]";

        return this.CollectionOf<Booking>(procedureName, 
                                                        new SqlParameter("@Id", bookingStatus_Id), 
                                                        new SqlParameter("@jsonValue", booking.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
