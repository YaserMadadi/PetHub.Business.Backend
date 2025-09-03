
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

public class EnterpriseProviderInsurance_Service : Service<EnterpriseProviderInsurance>, IEnterpriseProviderInsurance_Service
{
    public EnterpriseProviderInsurance_Service() : base()
    {
    }

    public override async Task<DataResult<EnterpriseProviderInsurance>> SaveAttached(EnterpriseProviderInsurance enterpriseProviderInsurance, UserCredit userCredit)
    {
        return await enterpriseProviderInsurance.SaveAttached(userCredit);
    }

    
}
