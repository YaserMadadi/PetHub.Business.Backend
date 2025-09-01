
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Base;
using PetHub.Services.Base.Actions;
using PetHub.Services.Base.Abstract;

namespace PetHub.Services.Base;

public class WeightUnit_Service : Service<WeightUnit>, IWeightUnit_Service
{
    public WeightUnit_Service() : base()
    {
    }

    public override async Task<DataResult<WeightUnit>> SaveAttached(WeightUnit weightUnit, UserCredit userCredit)
    {
        return await weightUnit.SaveAttached(userCredit);
    }

    public DataResult<List<Pet>> CollectionOfPet(int weightUnit_Id, Pet pet, UserCredit userCredit)
    {
        var procedureName = "[Base].[WeightUnit.CollectionOfPet]";

        return this.CollectionOf<Pet>(procedureName, 
                                                        new SqlParameter("@Id", weightUnit_Id), 
                                                        new SqlParameter("@jsonValue", pet.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
