

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

public static class RolePermission_Action
{
	
    public static async Task<DataResult<RolePermission>> SaveAttached(this RolePermission rolePermission, UserCredit userCredit)
    {
        var permissionType = rolePermission.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(rolePermission.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<RolePermission>(-1, "You don't have Save Permission for ''RolePermission''", rolePermission);

        return await rolePermission.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<RolePermission>> SaveAttached(this RolePermission rolePermission, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IRolePermission_Service rolePermissionService = new RolePermission_Service();

        var result = await rolePermissionService.Save(rolePermission, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<RolePermission>(rolePermission);

        transaction.Commit();

        result = await rolePermissionService.RetrieveById(result.Id, RolePermission.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<RolePermission>> SaveCollection(this List<RolePermission> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<RolePermission> result = new SuccessfulDataResult<RolePermission>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
