

using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using PetHub.Entities.Base;
using PetHub.Services.Base.Abstract;


namespace PetHub.Services.Base.Actions;

public static class City_Action
{
	
    public static async Task<DataResult<City>> SaveAttached(this City city, UserCredit userCredit)
    {
        var permissionType = city.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(city.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<City>(-1, "You don't have Save Permission for ''City''", city);

        return await city.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<City>> SaveAttached(this City city, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ICity_Service cityService = new City_Service();

        var result = await cityService.Save(city, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<City>(city);

        transaction.Commit();

        result = await cityService.RetrieveById(result.Id, City.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<City>> SaveCollection(this List<City> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<City> result = new SuccessfulDataResult<City>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
