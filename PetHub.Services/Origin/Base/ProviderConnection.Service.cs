
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

public class ProviderConnection_Service : Service<ProviderConnection>, IProviderConnection_Service
{
    public ProviderConnection_Service() : base()
    {
    }

    public override async Task<DataResult<ProviderConnection>> SaveAttached(ProviderConnection providerConnection, UserCredit userCredit)
    {
        return await providerConnection.SaveAttached(userCredit);
    }

    
}
