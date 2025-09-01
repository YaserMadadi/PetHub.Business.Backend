

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

public static class ResultMessage_Action
{
	
    public static async Task<DataResult<ResultMessage>> SaveAttached(this ResultMessage resultMessage, UserCredit userCredit)
    {
        var permissionType = resultMessage.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(resultMessage.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ResultMessage>(-1, "You don't have Save Permission for ''ResultMessage''", resultMessage);

        return await resultMessage.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ResultMessage>> SaveAttached(this ResultMessage resultMessage, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IResultMessage_Service resultMessageService = new ResultMessage_Service();

        var result = await resultMessageService.Save(resultMessage, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ResultMessage>(resultMessage);

        transaction.Commit();

        result = await resultMessageService.RetrieveById(result.Id, ResultMessage.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ResultMessage>> SaveCollection(this List<ResultMessage> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ResultMessage> result = new SuccessfulDataResult<ResultMessage>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
