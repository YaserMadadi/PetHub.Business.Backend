

using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using PetHub.Entities.Admin;
using PetHub.Services.Admin.Abstract;


namespace PetHub.Services.Admin.Actions;

public static class Role_Action
{
	
    public static async Task<DataResult<Role>> SaveAttached(this Role role, UserCredit userCredit)
    {
        var permissionType = role.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(role.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Role>(-1, "You don't have Save Permission for ''Role''", role);

        return await role.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Role>> SaveAttached(this Role role, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IRole_Service roleService = new Role_Service();

        var result = await roleService.Save(role, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Role>(role);

        transaction.Commit();

        result = await roleService.RetrieveById(result.Id, Role.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Role>> SaveCollection(this List<Role> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Role> result = new SuccessfulDataResult<Role>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
