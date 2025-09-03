
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;
using PetHub.Entities.Fund;

namespace PetHub.Services.Base.Abstract;

public interface IClient_Service : IService<Client>
{
    DataResult<List<ClientNotification>> CollectionOfClientNotification(int clientNotification_Id, ClientNotification clientNotification, UserCredit userCredit);

	DataResult<List<ClientReview>> CollectionOfClientReview(int clientReview_Id, ClientReview clientReview, UserCredit userCredit);

	DataResult<List<ClientWallet>> CollectionOfClientWallet(int clientWallet_Id, ClientWallet clientWallet, UserCredit userCredit);

	DataResult<List<Pet>> CollectionOfPet(int pet_Id, Pet pet, UserCredit userCredit);

	DataResult<List<PhoneNumberVerification>> CollectionOfPhoneNumberVerification(int phoneNumberVerification_Id, PhoneNumberVerification phoneNumberVerification, UserCredit userCredit);
}
