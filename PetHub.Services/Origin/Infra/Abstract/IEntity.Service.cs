
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Infra;
using PetHub.Entities.Admin;

namespace PetHub.Services.Infra.Abstract;

public interface IEntity_Service : IService<Entity>
{
    DataResult<List<RolePermission>> CollectionOfRolePermission(int rolePermission_Id, RolePermission rolePermission, UserCredit userCredit);

	DataResult<List<StaffPermission>> CollectionOfStaffPermission(int staffPermission_Id, StaffPermission staffPermission, UserCredit userCredit);
}
