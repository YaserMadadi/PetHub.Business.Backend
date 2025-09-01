
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

public class LocationCoverage_Service : Service<LocationCoverage>, ILocationCoverage_Service
{
    public LocationCoverage_Service() : base()
    {
    }

    public override async Task<DataResult<LocationCoverage>> SaveAttached(LocationCoverage locationCoverage, UserCredit userCredit)
    {
        return await locationCoverage.SaveAttached(userCredit);
    }

    
}
