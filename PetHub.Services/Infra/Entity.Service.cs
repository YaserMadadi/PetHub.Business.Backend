
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

public class Entity_Service : Service<Entity>, IEntity_Service
{
    public Entity_Service() : base()
    {
    }

    public override async Task<DataResult<Entity>> SaveAttached(Entity entity, UserCredit userCredit)
    {
        return await entity.SaveAttached(userCredit);
    }

    
}
