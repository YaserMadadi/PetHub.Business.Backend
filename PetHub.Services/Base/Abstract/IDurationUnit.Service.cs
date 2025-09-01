
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IDurationUnit_Service : IService<DurationUnit>
{
    DataResult<List<Booking>> CollectionOfBooking(int booking_Id, Booking booking, UserCredit userCredit);
}
