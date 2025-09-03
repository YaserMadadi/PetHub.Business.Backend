

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

public static class StaffPermission_Action
{
	
    public static async Task<DataResult<StaffPermission>> SaveAttached(this StaffPermission staffPermission, UserCredit userCredit)
    {
        var permissionType = staffPermission.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(staffPermission.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<StaffPermission>(-1, "You don't have Save Permission for ''StaffPermission''", staffPermission);

        return await staffPermission.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<StaffPermission>> SaveAttached(this StaffPermission staffPermission, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IStaffPermission_Service staffPermissionService = new StaffPermission_Service();

        var result = await staffPermissionService.Save(staffPermission, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<StaffPermission>(staffPermission);

        transaction.Commit();

        result = await staffPermissionService.RetrieveById(result.Id, StaffPermission.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<StaffPermission>> SaveCollection(this List<StaffPermission> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<StaffPermission> result = new SuccessfulDataResult<StaffPermission>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
