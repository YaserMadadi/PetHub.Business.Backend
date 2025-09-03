
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

public class ProviderService_Service : Service<ProviderService>, IProviderService_Service
{
    public ProviderService_Service() : base()
    {
    }

    public override async Task<DataResult<ProviderService>> SaveAttached(ProviderService providerService, UserCredit userCredit)
    {
        return await providerService.SaveAttached(userCredit);
    }

    public DataResult<List<BookingService>> CollectionOfBookingService(int providerService_Id, BookingService bookingService, UserCredit userCredit)
    {
        var procedureName = "[Base].[ProviderService.CollectionOfBookingService]";

        return this.CollectionOf<BookingService>(procedureName, 
                                                        new SqlParameter("@Id", providerService_Id), 
                                                        new SqlParameter("@jsonValue", bookingService.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ServiceOrientedWorkTime>> CollectionOfServiceOrientedWorkTime(int providerService_Id, ServiceOrientedWorkTime serviceOrientedWorkTime, UserCredit userCredit)
    {
        var procedureName = "[Base].[ProviderService.CollectionOfServiceOrientedWorkTime]";

        return this.CollectionOf<ServiceOrientedWorkTime>(procedureName, 
                                                        new SqlParameter("@Id", providerService_Id), 
                                                        new SqlParameter("@jsonValue", serviceOrientedWorkTime.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ServicePrice>> CollectionOfServicePrice(int providerService_Id, ServicePrice servicePrice, UserCredit userCredit)
    {
        var procedureName = "[Base].[ProviderService.CollectionOfServicePrice]";

        return this.CollectionOf<ServicePrice>(procedureName, 
                                                        new SqlParameter("@Id", providerService_Id), 
                                                        new SqlParameter("@jsonValue", servicePrice.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
