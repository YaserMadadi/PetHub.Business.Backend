
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Admin;

namespace PetHub.Services.Admin.Abstract;

public interface IRole_Service : IService<Role>
{
    DataResult<List<RoleMember>> CollectionOfRoleMember(int roleMember_Id, RoleMember roleMember, UserCredit userCredit);

	DataResult<List<RolePermission>> CollectionOfRolePermission(int rolePermission_Id, RolePermission rolePermission, UserCredit userCredit);
}
