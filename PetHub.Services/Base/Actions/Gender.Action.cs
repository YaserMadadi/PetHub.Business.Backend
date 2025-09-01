

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

public static class Gender_Action
{
	
    public static async Task<DataResult<Gender>> SaveAttached(this Gender gender, UserCredit userCredit)
    {
        var permissionType = gender.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(gender.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Gender>(-1, "You don't have Save Permission for ''Gender''", gender);

        return await gender.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Gender>> SaveAttached(this Gender gender, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IGender_Service genderService = new Gender_Service();

        var result = await genderService.Save(gender, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Gender>(gender);

        transaction.Commit();

        result = await genderService.RetrieveById(result.Id, Gender.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Gender>> SaveCollection(this List<Gender> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Gender> result = new SuccessfulDataResult<Gender>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
