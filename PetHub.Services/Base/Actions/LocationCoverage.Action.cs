

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

public static class LocationCoverage_Action
{
	
    public static async Task<DataResult<LocationCoverage>> SaveAttached(this LocationCoverage locationCoverage, UserCredit userCredit)
    {
        var permissionType = locationCoverage.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(locationCoverage.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<LocationCoverage>(-1, "You don't have Save Permission for ''LocationCoverage''", locationCoverage);

        return await locationCoverage.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<LocationCoverage>> SaveAttached(this LocationCoverage locationCoverage, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ILocationCoverage_Service locationCoverageService = new LocationCoverage_Service();

        var result = await locationCoverageService.Save(locationCoverage, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<LocationCoverage>(locationCoverage);

        transaction.Commit();

        result = await locationCoverageService.RetrieveById(result.Id, LocationCoverage.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<LocationCoverage>> SaveCollection(this List<LocationCoverage> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<LocationCoverage> result = new SuccessfulDataResult<LocationCoverage>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
