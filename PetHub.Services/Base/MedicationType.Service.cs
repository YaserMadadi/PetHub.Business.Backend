
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

public class MedicationType_Service : Service<MedicationType>, IMedicationType_Service
{
    public MedicationType_Service() : base()
    {
    }

    public override async Task<DataResult<MedicationType>> SaveAttached(MedicationType medicationType, UserCredit userCredit)
    {
        return await medicationType.SaveAttached(userCredit);
    }

    public DataResult<List<PetMedicalCondition>> CollectionOfPetMedicalCondition(int medicationType_Id, PetMedicalCondition petMedicalCondition, UserCredit userCredit)
    {
        var procedureName = "[Base].[MedicationType.CollectionOfPetMedicalCondition]";

        return this.CollectionOf<PetMedicalCondition>(procedureName, 
                                                        new SqlParameter("@Id", medicationType_Id), 
                                                        new SqlParameter("@jsonValue", petMedicalCondition.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
