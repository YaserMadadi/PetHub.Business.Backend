
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

public class ServicePrice_Service : Service<ServicePrice>, IServicePrice_Service
{
    public ServicePrice_Service() : base()
    {
    }

    public override async Task<DataResult<ServicePrice>> SaveAttached(ServicePrice servicePrice, UserCredit userCredit)
    {
        return await servicePrice.SaveAttached(userCredit);
    }

    
}
