
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IProviderService_Service : IService<ProviderService>
{
    DataResult<List<BookingService>> CollectionOfBookingService(int bookingService_Id, BookingService bookingService, UserCredit userCredit);

	DataResult<List<ServiceOrientedWorkTime>> CollectionOfServiceOrientedWorkTime(int serviceOrientedWorkTime_Id, ServiceOrientedWorkTime serviceOrientedWorkTime, UserCredit userCredit);

	DataResult<List<ServicePrice>> CollectionOfServicePrice(int servicePrice_Id, ServicePrice servicePrice, UserCredit userCredit);
}
