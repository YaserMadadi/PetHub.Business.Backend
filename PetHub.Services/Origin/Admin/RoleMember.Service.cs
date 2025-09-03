
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

public class RoleMember_Service : Service<RoleMember>, IRoleMember_Service
{
    public RoleMember_Service() : base()
    {
    }

    public override async Task<DataResult<RoleMember>> SaveAttached(RoleMember roleMember, UserCredit userCredit)
    {
        return await roleMember.SaveAttached(userCredit);
    }

    
}
