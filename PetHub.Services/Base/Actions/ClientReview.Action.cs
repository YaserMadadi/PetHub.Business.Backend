

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

public static class ClientReview_Action
{
	
    public static async Task<DataResult<ClientReview>> SaveAttached(this ClientReview clientReview, UserCredit userCredit)
    {
        var permissionType = clientReview.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(clientReview.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<ClientReview>(-1, "You don't have Save Permission for ''ClientReview''", clientReview);

        return await clientReview.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<ClientReview>> SaveAttached(this ClientReview clientReview, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IClientReview_Service clientReviewService = new ClientReview_Service();

        var result = await clientReviewService.Save(clientReview, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        

        if (depth > 0)

            return new SuccessfulDataResult<ClientReview>(clientReview);

        transaction.Commit();

        result = await clientReviewService.RetrieveById(result.Id, ClientReview.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<ClientReview>> SaveCollection(this List<ClientReview> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<ClientReview> result = new SuccessfulDataResult<ClientReview>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
