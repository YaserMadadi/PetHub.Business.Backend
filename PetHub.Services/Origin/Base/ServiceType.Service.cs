
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

public class ServiceType_Service : Service<ServiceType>, IServiceType_Service
{
    public ServiceType_Service() : base()
    {
    }

    public override async Task<DataResult<ServiceType>> SaveAttached(ServiceType serviceType, UserCredit userCredit)
    {
        return await serviceType.SaveAttached(userCredit);
    }

    public DataResult<List<ProviderService>> CollectionOfProviderService(int serviceType_Id, ProviderService providerService, UserCredit userCredit)
    {
        var procedureName = "[Base].[ServiceType.CollectionOfProviderService]";

        return this.CollectionOf<ProviderService>(procedureName, 
                                                        new SqlParameter("@Id", serviceType_Id), 
                                                        new SqlParameter("@jsonValue", providerService.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
