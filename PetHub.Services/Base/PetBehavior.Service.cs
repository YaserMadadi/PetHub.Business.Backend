
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

public class PetBehavior_Service : Service<PetBehavior>, IPetBehavior_Service
{
    public PetBehavior_Service() : base()
    {
    }

    public override async Task<DataResult<PetBehavior>> SaveAttached(PetBehavior petBehavior, UserCredit userCredit)
    {
        return await petBehavior.SaveAttached(userCredit);
    }

    
}
