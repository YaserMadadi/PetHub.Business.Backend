

using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using PetHub.Entities.Infra;
using PetHub.Services.Infra.Abstract;


namespace PetHub.Services.Infra.Actions;

public static class ExceptionBackend_Action
{
	
    public static async Task<DataResult<ExceptionBackend>> SaveAttached(this ExceptionBackend exceptionBackend, UserCredit userCredit)
    {
        var permissionType = exceptionBackend.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(exceptionBackend.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ExceptionBackend>(-1, "You don't have Save Permission for ''ExceptionBackend''", exceptionBackend);

        return await exceptionBackend.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ExceptionBackend>> SaveAttached(this ExceptionBackend exceptionBackend, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IExceptionBackend_Service exceptionBackendService = new ExceptionBackend_Service();

        var result = await exceptionBackendService.Save(exceptionBackend, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ExceptionBackend>(exceptionBackend);

        transaction.Commit();

        result = await exceptionBackendService.RetrieveById(result.Id, ExceptionBackend.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ExceptionBackend>> SaveCollection(this List<ExceptionBackend> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ExceptionBackend> result = new SuccessfulDataResult<ExceptionBackend>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
