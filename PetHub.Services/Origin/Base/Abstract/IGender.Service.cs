
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;
using PetHub.Entities.Admin;

namespace PetHub.Services.Base.Abstract;

public interface IGender_Service : IService<Gender>
{
    DataResult<List<Client>> CollectionOfClient(int client_Id, Client client, UserCredit userCredit);

	DataResult<List<IndividualProvider>> CollectionOfIndividualProvider(int individualProvider_Id, IndividualProvider individualProvider, UserCredit userCredit);

	DataResult<List<Pet>> CollectionOfPet(int pet_Id, Pet pet, UserCredit userCredit);

	DataResult<List<Staff>> CollectionOfStaff(int staff_Id, Staff staff, UserCredit userCredit);
}
