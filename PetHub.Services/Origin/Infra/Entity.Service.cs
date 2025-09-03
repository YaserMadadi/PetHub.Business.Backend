
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
using PetHub.Entities.Admin;

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

    public DataResult<List<RolePermission>> CollectionOfRolePermission(int entity_Id, RolePermission rolePermission, UserCredit userCredit)
    {
        var procedureName = "[Infra].[Entity.CollectionOfRolePermission]";

        return this.CollectionOf<RolePermission>(procedureName, 
                                                        new SqlParameter("@Id", entity_Id), 
                                                        new SqlParameter("@jsonValue", rolePermission.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<StaffPermission>> CollectionOfStaffPermission(int entity_Id, StaffPermission staffPermission, UserCredit userCredit)
    {
        var procedureName = "[Infra].[Entity.CollectionOfStaffPermission]";

        return this.CollectionOf<StaffPermission>(procedureName, 
                                                        new SqlParameter("@Id", entity_Id), 
                                                        new SqlParameter("@jsonValue", staffPermission.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
