
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

public class BehaviorCategory_Service : Service<BehaviorCategory>, IBehaviorCategory_Service
{
    public BehaviorCategory_Service() : base()
    {
    }

    public override async Task<DataResult<BehaviorCategory>> SaveAttached(BehaviorCategory behaviorCategory, UserCredit userCredit)
    {
        return await behaviorCategory.SaveAttached(userCredit);
    }

    public DataResult<List<PetBehavior>> CollectionOfPetBehavior(int behaviorCategory_Id, PetBehavior petBehavior, UserCredit userCredit)
    {
        var procedureName = "[Base].[BehaviorCategory.CollectionOfPetBehavior]";

        return this.CollectionOf<PetBehavior>(procedureName, 
                                                        new SqlParameter("@Id", behaviorCategory_Id), 
                                                        new SqlParameter("@jsonValue", petBehavior.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
