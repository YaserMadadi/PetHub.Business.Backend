
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

public class ProviderPayOut_Service : Service<ProviderPayOut>, IProviderPayOut_Service
{
    public ProviderPayOut_Service() : base()
    {
    }

    public override async Task<DataResult<ProviderPayOut>> SaveAttached(ProviderPayOut providerPayOut, UserCredit userCredit)
    {
        return await providerPayOut.SaveAttached(userCredit);
    }

    
}
