

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

public static class Country_Action
{
	
    public static async Task<DataResult<Country>> SaveAttached(this Country country, UserCredit userCredit)
    {
        var permissionType = country.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(country.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Country>(-1, "You don't have Save Permission for ''Country''", country);

        return await country.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Country>> SaveAttached(this Country country, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ICountry_Service countryService = new Country_Service();

        var result = await countryService.Save(country, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Country>(country);

        transaction.Commit();

        result = await countryService.RetrieveById(result.Id, Country.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Country>> SaveCollection(this List<Country> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Country> result = new SuccessfulDataResult<Country>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
