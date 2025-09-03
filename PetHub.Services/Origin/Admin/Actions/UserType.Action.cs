

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
using PetHub.Services.Base.Actions;
using PetHub.Entities.Base;


namespace PetHub.Services.Admin.Actions;

public static class UserType_Action
{
	
    public static async Task<DataResult<UserType>> SaveAttached(this UserType userType, UserCredit userCredit)
    {
        var permissionType = userType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(userType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<UserType>(-1, "You don't have Save Permission for ''UserType''", userType);

        return await userType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<UserType>> SaveAttached(this UserType userType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IUserType_Service userTypeService = new UserType_Service();

        var result = await userTypeService.Save(userType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<UserType>(userType);

        transaction.Commit();

        result = await userTypeService.RetrieveById(result.Id, UserType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<UserType>> SaveCollection(this List<UserType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<UserType> result = new SuccessfulDataResult<UserType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
