
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IBank_Service : IService<Bank>
{
    DataResult<List<ProviderBankAccount>> CollectionOfProviderBankAccount(int providerBankAccount_Id, ProviderBankAccount providerBankAccount, UserCredit userCredit);
}
