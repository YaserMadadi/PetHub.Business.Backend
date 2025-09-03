

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

public static class MessageType_Action
{
	
    public static async Task<DataResult<MessageType>> SaveAttached(this MessageType messageType, UserCredit userCredit)
    {
        var permissionType = messageType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(messageType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<MessageType>(-1, "You don't have Save Permission for ''MessageType''", messageType);

        return await messageType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<MessageType>> SaveAttached(this MessageType messageType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IMessageType_Service messageTypeService = new MessageType_Service();

        var result = await messageTypeService.Save(messageType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<MessageType>(messageType);

        transaction.Commit();

        result = await messageTypeService.RetrieveById(result.Id, MessageType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<MessageType>> SaveCollection(this List<MessageType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<MessageType> result = new SuccessfulDataResult<MessageType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
