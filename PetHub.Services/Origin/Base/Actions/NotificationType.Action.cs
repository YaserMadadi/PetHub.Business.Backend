

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

public static class NotificationType_Action
{
	
    public static async Task<DataResult<NotificationType>> SaveAttached(this NotificationType notificationType, UserCredit userCredit)
    {
        var permissionType = notificationType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(notificationType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<NotificationType>(-1, "You don't have Save Permission for ''NotificationType''", notificationType);

        return await notificationType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<NotificationType>> SaveAttached(this NotificationType notificationType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        INotificationType_Service notificationTypeService = new NotificationType_Service();

        var result = await notificationTypeService.Save(notificationType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<NotificationType>(notificationType);

        transaction.Commit();

        result = await notificationTypeService.RetrieveById(result.Id, NotificationType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<NotificationType>> SaveCollection(this List<NotificationType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<NotificationType> result = new SuccessfulDataResult<NotificationType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
