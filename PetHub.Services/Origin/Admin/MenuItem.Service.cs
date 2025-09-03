
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

public class MenuItem_Service : Service<MenuItem>, IMenuItem_Service
{
    public MenuItem_Service() : base()
    {
    }

    public override async Task<DataResult<MenuItem>> SaveAttached(MenuItem menuItem, UserCredit userCredit)
    {
        return await menuItem.SaveAttached(userCredit);
    }

    
}
