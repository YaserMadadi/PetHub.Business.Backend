
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

public class InsuranceType_Service : Service<InsuranceType>, IInsuranceType_Service
{
    public InsuranceType_Service() : base()
    {
    }

    public override async Task<DataResult<InsuranceType>> SaveAttached(InsuranceType insuranceType, UserCredit userCredit)
    {
        return await insuranceType.SaveAttached(userCredit);
    }

    
}
