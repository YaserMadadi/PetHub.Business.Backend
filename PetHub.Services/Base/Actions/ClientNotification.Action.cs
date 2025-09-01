

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

public static class ClientNotification_Action
{
	
    public static async Task<DataResult<ClientNotification>> SaveAttached(this ClientNotification clientNotification, UserCredit userCredit)
    {
        var permissionType = clientNotification.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(clientNotification.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ClientNotification>(-1, "You don't have Save Permission for ''ClientNotification''", clientNotification);

        return await clientNotification.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ClientNotification>> SaveAttached(this ClientNotification clientNotification, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IClientNotification_Service clientNotificationService = new ClientNotification_Service();

        var result = await clientNotificationService.Save(clientNotification, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ClientNotification>(clientNotification);

        transaction.Commit();

        result = await clientNotificationService.RetrieveById(result.Id, ClientNotification.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ClientNotification>> SaveCollection(this List<ClientNotification> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ClientNotification> result = new SuccessfulDataResult<ClientNotification>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
