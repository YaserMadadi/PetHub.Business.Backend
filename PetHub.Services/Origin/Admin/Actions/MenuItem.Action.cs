

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

public static class MenuItem_Action
{
	
    public static async Task<DataResult<MenuItem>> SaveAttached(this MenuItem menuItem, UserCredit userCredit)
    {
        var permissionType = menuItem.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(menuItem.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<MenuItem>(-1, "You don't have Save Permission for ''MenuItem''", menuItem);

        return await menuItem.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<MenuItem>> SaveAttached(this MenuItem menuItem, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IMenuItem_Service menuItemService = new MenuItem_Service();

        var result = await menuItemService.Save(menuItem, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<MenuItem>(menuItem);

        transaction.Commit();

        result = await menuItemService.RetrieveById(result.Id, MenuItem.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<MenuItem>> SaveCollection(this List<MenuItem> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<MenuItem> result = new SuccessfulDataResult<MenuItem>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
