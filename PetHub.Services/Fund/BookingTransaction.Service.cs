
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Fund;
using PetHub.Services.Fund.Actions;
using PetHub.Services.Fund.Abstract;

namespace PetHub.Services.Fund;

public class BookingTransaction_Service : Service<BookingTransaction>, IBookingTransaction_Service
{
    public BookingTransaction_Service() : base()
    {
    }

    public override async Task<DataResult<BookingTransaction>> SaveAttached(BookingTransaction bookingTransaction, UserCredit userCredit)
    {
        return await bookingTransaction.SaveAttached(userCredit);
    }

    
}
