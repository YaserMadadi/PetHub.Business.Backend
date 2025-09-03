
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

public class RolePermission_Service : Service<RolePermission>, IRolePermission_Service
{
    public RolePermission_Service() : base()
    {
    }

    public override async Task<DataResult<RolePermission>> SaveAttached(RolePermission rolePermission, UserCredit userCredit)
    {
        return await rolePermission.SaveAttached(userCredit);
    }

    
}
