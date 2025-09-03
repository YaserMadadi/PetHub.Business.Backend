

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

public static class Menu_Action
{
	
    public static async Task<DataResult<Menu>> SaveAttached(this Menu menu, UserCredit userCredit)
    {
        var permissionType = menu.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(menu.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Menu>(-1, "You don't have Save Permission for ''Menu''", menu);

        return await menu.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Menu>> SaveAttached(this Menu menu, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IMenu_Service menuService = new Menu_Service();

        var result = await menuService.Save(menu, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Menu>(menu);

        transaction.Commit();

        result = await menuService.RetrieveById(result.Id, Menu.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Menu>> SaveCollection(this List<Menu> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Menu> result = new SuccessfulDataResult<Menu>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
