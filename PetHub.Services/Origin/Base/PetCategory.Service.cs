
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

public class PetCategory_Service : Service<PetCategory>, IPetCategory_Service
{
    public PetCategory_Service() : base()
    {
    }

    public override async Task<DataResult<PetCategory>> SaveAttached(PetCategory petCategory, UserCredit userCredit)
    {
        return await petCategory.SaveAttached(userCredit);
    }

    public DataResult<List<AcceptedPetCategory>> CollectionOfAcceptedPetCategory(int petCategory_Id, AcceptedPetCategory acceptedPetCategory, UserCredit userCredit)
    {
        var procedureName = "[Base].[PetCategory.CollectionOfAcceptedPetCategory]";

        return this.CollectionOf<AcceptedPetCategory>(procedureName, 
                                                        new SqlParameter("@Id", petCategory_Id), 
                                                        new SqlParameter("@jsonValue", acceptedPetCategory.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
