
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;
using PetHub.Entities.Fund;

namespace PetHub.Services.Base.Abstract;

public interface IBooking_Service : IService<Booking>
{
    DataResult<List<BookingService>> CollectionOfBookingService(int bookingService_Id, BookingService bookingService, UserCredit userCredit);

	DataResult<List<BookingTransaction>> CollectionOfBookingTransaction(int bookingTransaction_Id, BookingTransaction bookingTransaction, UserCredit userCredit);
}
