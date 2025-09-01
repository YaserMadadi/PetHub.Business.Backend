
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Infra;
using PetHub.Services.Infra.Actions;
using PetHub.Services.Infra.Abstract;

namespace PetHub.Services.Infra;

public class CheckConstraint_Service : Service<CheckConstraint>, ICheckConstraint_Service
{
    public CheckConstraint_Service() : base()
    {
    }

    public override async Task<DataResult<CheckConstraint>> SaveAttached(CheckConstraint checkConstraint, UserCredit userCredit)
    {
        return await checkConstraint.SaveAttached(userCredit);
    }

    
}
