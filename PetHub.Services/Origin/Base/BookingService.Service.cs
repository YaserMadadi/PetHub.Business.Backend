
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

public class BookingService_Service : Service<BookingService>, IBookingService_Service
{
    public BookingService_Service() : base()
    {
    }

    public override async Task<DataResult<BookingService>> SaveAttached(BookingService bookingService, UserCredit userCredit)
    {
        return await bookingService.SaveAttached(userCredit);
    }

    
}
