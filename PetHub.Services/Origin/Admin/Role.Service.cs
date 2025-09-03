
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

public class Role_Service : Service<Role>, IRole_Service
{
    public Role_Service() : base()
    {
    }

    public override async Task<DataResult<Role>> SaveAttached(Role role, UserCredit userCredit)
    {
        return await role.SaveAttached(userCredit);
    }

    public DataResult<List<RoleMember>> CollectionOfRoleMember(int role_Id, RoleMember roleMember, UserCredit userCredit)
    {
        var procedureName = "[Admin].[Role.CollectionOfRoleMember]";

        return this.CollectionOf<RoleMember>(procedureName, 
                                                        new SqlParameter("@Id", role_Id), 
                                                        new SqlParameter("@jsonValue", roleMember.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<RolePermission>> CollectionOfRolePermission(int role_Id, RolePermission rolePermission, UserCredit userCredit)
    {
        var procedureName = "[Admin].[Role.CollectionOfRolePermission]";

        return this.CollectionOf<RolePermission>(procedureName, 
                                                        new SqlParameter("@Id", role_Id), 
                                                        new SqlParameter("@jsonValue", rolePermission.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
