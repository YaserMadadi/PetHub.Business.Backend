
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;
using PetHub.Entities.Admin;

namespace PetHub.Services.Base.Abstract;

public interface IUserAccount_Service : IService<UserAccount>
{
    DataResult<List<Client>> CollectionOfClient(int client_Id, Client client, UserCredit userCredit);

	DataResult<List<EmailVerification>> CollectionOfEmailVerification(int emailVerification_Id, EmailVerification emailVerification, UserCredit userCredit);

	DataResult<List<Provider>> CollectionOfProvider(int provider_Id, Provider provider, UserCredit userCredit);

	DataResult<List<RoleMember>> CollectionOfRoleMember(int roleMember_Id, RoleMember roleMember, UserCredit userCredit);

	DataResult<List<Staff>> CollectionOfStaff(int staff_Id, Staff staff, UserCredit userCredit);
}
