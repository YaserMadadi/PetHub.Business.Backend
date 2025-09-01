
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IVerificationStatus_Service : IService<VerificationStatus>
{
    DataResult<List<Client>> CollectionOfClient(int client_Id, Client client, UserCredit userCredit);

	DataResult<List<EmailVerification>> CollectionOfEmailVerification(int emailVerification_Id, EmailVerification emailVerification, UserCredit userCredit);

	DataResult<List<PhoneNumberVerification>> CollectionOfPhoneNumberVerification(int phoneNumberVerification_Id, PhoneNumberVerification phoneNumberVerification, UserCredit userCredit);
}
