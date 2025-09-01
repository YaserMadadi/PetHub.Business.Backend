
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Fund;

namespace PetHub.Services.Fund.Abstract;

public interface IProviderWallet_Service : IService<ProviderWallet>
{
    DataResult<List<BookingTransaction>> CollectionOfBookingTransaction(int bookingTransaction_Id, BookingTransaction bookingTransaction, UserCredit userCredit);
}
