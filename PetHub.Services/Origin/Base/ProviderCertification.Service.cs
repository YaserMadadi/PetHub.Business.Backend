
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

public class ProviderCertification_Service : Service<ProviderCertification>, IProviderCertification_Service
{
    public ProviderCertification_Service() : base()
    {
    }

    public override async Task<DataResult<ProviderCertification>> SaveAttached(ProviderCertification providerCertification, UserCredit userCredit)
    {
        return await providerCertification.SaveAttached(userCredit);
    }

    
}
