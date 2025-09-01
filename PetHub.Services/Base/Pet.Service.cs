
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

public class Pet_Service : Service<Pet>, IPet_Service
{
    public Pet_Service() : base()
    {
    }

    public override async Task<DataResult<Pet>> SaveAttached(Pet pet, UserCredit userCredit)
    {
        return await pet.SaveAttached(userCredit);
    }

    public DataResult<List<Booking>> CollectionOfBooking(int pet_Id, Booking booking, UserCredit userCredit)
    {
        var procedureName = "[Base].[Pet.CollectionOfBooking]";

        return this.CollectionOf<Booking>(procedureName, 
                                                        new SqlParameter("@Id", pet_Id), 
                                                        new SqlParameter("@jsonValue", booking.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<PetBehavior>> CollectionOfPetBehavior(int pet_Id, PetBehavior petBehavior, UserCredit userCredit)
    {
        var procedureName = "[Base].[Pet.CollectionOfPetBehavior]";

        return this.CollectionOf<PetBehavior>(procedureName, 
                                                        new SqlParameter("@Id", pet_Id), 
                                                        new SqlParameter("@jsonValue", petBehavior.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<PetMedicalCondition>> CollectionOfPetMedicalCondition(int pet_Id, PetMedicalCondition petMedicalCondition, UserCredit userCredit)
    {
        var procedureName = "[Base].[Pet.CollectionOfPetMedicalCondition]";

        return this.CollectionOf<PetMedicalCondition>(procedureName, 
                                                        new SqlParameter("@Id", pet_Id), 
                                                        new SqlParameter("@jsonValue", petMedicalCondition.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
