
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

public class Gender_Service : Service<Gender>, IGender_Service
{
    public Gender_Service() : base()
    {
    }

    public override async Task<DataResult<Gender>> SaveAttached(Gender gender, UserCredit userCredit)
    {
        return await gender.SaveAttached(userCredit);
    }

    public DataResult<List<Client>> CollectionOfClient(int gender_Id, Client client, UserCredit userCredit)
    {
        var procedureName = "[Base].[Gender.CollectionOfClient]";

        return this.CollectionOf<Client>(procedureName, 
                                                        new SqlParameter("@Id", gender_Id), 
                                                        new SqlParameter("@jsonValue", client.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<IndividualProvider>> CollectionOfIndividualProvider(int gender_Id, IndividualProvider individualProvider, UserCredit userCredit)
    {
        var procedureName = "[Base].[Gender.CollectionOfIndividualProvider]";

        return this.CollectionOf<IndividualProvider>(procedureName, 
                                                        new SqlParameter("@Id", gender_Id), 
                                                        new SqlParameter("@jsonValue", individualProvider.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<Pet>> CollectionOfPet(int gender_Id, Pet pet, UserCredit userCredit)
    {
        var procedureName = "[Base].[Gender.CollectionOfPet]";

        return this.CollectionOf<Pet>(procedureName, 
                                                        new SqlParameter("@Id", gender_Id), 
                                                        new SqlParameter("@jsonValue", pet.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
