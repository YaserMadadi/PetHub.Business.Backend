

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

public static class ConnectionType_Action
{
	
    public static async Task<DataResult<ConnectionType>> SaveAttached(this ConnectionType connectionType, UserCredit userCredit)
    {
        var permissionType = connectionType.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(connectionType.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ConnectionType>(-1, "You don't have Save Permission for ''ConnectionType''", connectionType);

        return await connectionType.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ConnectionType>> SaveAttached(this ConnectionType connectionType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IConnectionType_Service connectionTypeService = new ConnectionType_Service();

        var result = await connectionTypeService.Save(connectionType, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<ConnectionType>(connectionType);

        transaction.Commit();

        result = await connectionTypeService.RetrieveById(result.Id, ConnectionType.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ConnectionType>> SaveCollection(this List<ConnectionType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ConnectionType> result = new SuccessfulDataResult<ConnectionType>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
