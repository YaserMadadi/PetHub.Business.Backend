

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

public static class Staff_Action
{
	
    public static async Task<DataResult<Staff>> SaveAttached(this Staff staff, UserCredit userCredit)
    {
        var permissionType = staff.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(staff.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Staff>(-1, "You don't have Save Permission for ''Staff''", staff);

        return await staff.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Staff>> SaveAttached(this Staff staff, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IStaff_Service staffService = new Staff_Service();

        var result = await staffService.Save(staff, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Staff>(staff);

        transaction.Commit();

        result = await staffService.RetrieveById(result.Id, Staff.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Staff>> SaveCollection(this List<Staff> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Staff> result = new SuccessfulDataResult<Staff>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
