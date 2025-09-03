

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

public static class Pet_Action
{
	
    public static async Task<DataResult<Pet>> SaveAttached(this Pet pet, UserCredit userCredit)
    {
        var permissionType = pet.IsNew ? PermissionType.Add : PermissionType.Edit;

        var hasPermission = permissionType.CheckPermission(pet.Info, userCredit);

        if (!hasPermission)

            return new ErrorDataResult<Pet>(-1, "You don't have Save Permission for ''Pet''", pet);

        return await pet.SaveAttached(userCredit, new CoreTransaction());
    }

    public static async Task<DataResult<Pet>> SaveAttached(this Pet pet, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
    {
        IPet_Service petService = new Pet_Service();

        var result = await petService.Save(pet, userCredit, transaction);

        if (result.Id <= 0)

            return result;

        Result childResult = new Result(false);


        if (depth > 0)

            return new SuccessfulDataResult<Pet>(pet);

        transaction.Commit();

        result = await petService.RetrieveById(result.Id, Pet.Informer, userCredit);

        return result;
    }


    
    public static async Task<DataResult<Pet>> SaveCollection(this List<Pet> list, UserCredit userCredit, CoreTransaction transaction, int depth)
    {
        DataResult<Pet> result = new SuccessfulDataResult<Pet>();

        foreach (var item in list)
        {
            result = await item.SaveAttached(userCredit, transaction, depth + 1);

            if (result.Id <= 0)

                break;
        }

        return result;
    }
}
