
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

public class AcceptedPetCategory_Service : Service<AcceptedPetCategory>, IAcceptedPetCategory_Service
{
    public AcceptedPetCategory_Service() : base()
    {
    }

    public override async Task<DataResult<AcceptedPetCategory>> SaveAttached(AcceptedPetCategory acceptedPetCategory, UserCredit userCredit)
    {
        return await acceptedPetCategory.SaveAttached(userCredit);
    }

    
}
