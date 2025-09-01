

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

public static class RecordLog_Action
{
	
    public static async Task<DataResult<RecordLog>> SaveAttached(this RecordLog recordLog, UserCredit userCredit)
    {
        var permissionType = recordLog.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(recordLog.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<RecordLog>(-1, "You don't have Save Permission for ''RecordLog''", recordLog);

        return await recordLog.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<RecordLog>> SaveAttached(this RecordLog recordLog, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IRecordLog_Service recordLogService = new RecordLog_Service();

        var result = await recordLogService.Save(recordLog, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<RecordLog>(recordLog);

        transaction.Commit();

        result = await recordLogService.RetrieveById(result.Id, RecordLog.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<RecordLog>> SaveCollection(this List<RecordLog> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<RecordLog> result = new SuccessfulDataResult<RecordLog>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
