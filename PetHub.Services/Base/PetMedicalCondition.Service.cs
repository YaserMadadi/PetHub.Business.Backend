
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

public class PetMedicalCondition_Service : Service<PetMedicalCondition>, IPetMedicalCondition_Service
{
    public PetMedicalCondition_Service() : base()
    {
    }

    public override async Task<DataResult<PetMedicalCondition>> SaveAttached(PetMedicalCondition petMedicalCondition, UserCredit userCredit)
    {
        return await petMedicalCondition.SaveAttached(userCredit);
    }

    
}
