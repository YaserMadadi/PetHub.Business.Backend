

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

public static class ExceptionProcedure_Action
{
	
    public static async Task<DataResult<ExceptionProcedure>> SaveAttached(this ExceptionProcedure exceptionProcedure, UserCredit userCredit)
    {
        var permissionType = exceptionProcedure.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(exceptionProcedure.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ExceptionProcedure>(-1, "You don't have Save Permission for ''ExceptionProcedure''", exceptionProcedure);

        return await exceptionProcedure.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ExceptionProcedure>> SaveAttached(this ExceptionProcedure exceptionProcedure, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IExceptionProcedure_Service exceptionProcedureService = new ExceptionProcedure_Service();

        var result = await exceptionProcedureService.Save(exceptionProcedure, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ExceptionProcedure>(exceptionProcedure);

        transaction.Commit();

        result = await exceptionProcedureService.RetrieveById(result.Id, ExceptionProcedure.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ExceptionProcedure>> SaveCollection(this List<ExceptionProcedure> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ExceptionProcedure> result = new SuccessfulDataResult<ExceptionProcedure>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
