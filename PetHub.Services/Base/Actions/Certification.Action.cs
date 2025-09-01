

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

public static class Certification_Action
{
	
    public static async Task<DataResult<Certification>> SaveAttached(this Certification certification, UserCredit userCredit)
    {
        var permissionType = certification.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(certification.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Certification>(-1, "You don't have Save Permission for ''Certification''", certification);

        return await certification.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Certification>> SaveAttached(this Certification certification, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        ICertification_Service certificationService = new Certification_Service();

        var result = await certificationService.Save(certification, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Certification>(certification);

        transaction.Commit();

        result = await certificationService.RetrieveById(result.Id, Certification.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Certification>> SaveCollection(this List<Certification> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Certification> result = new SuccessfulDataResult<Certification>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
