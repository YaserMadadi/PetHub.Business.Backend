
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Admin;
using PetHub.Services.Admin.Actions;
using PetHub.Services.Admin.Abstract;

namespace PetHub.Services.Admin;

public class StaffPermission_Service : Service<StaffPermission>, IStaffPermission_Service
{
    public StaffPermission_Service() : base()
    {
    }

    public override async Task<DataResult<StaffPermission>> SaveAttached(StaffPermission staffPermission, UserCredit userCredit)
    {
        return await staffPermission.SaveAttached(userCredit);
    }

    
}
