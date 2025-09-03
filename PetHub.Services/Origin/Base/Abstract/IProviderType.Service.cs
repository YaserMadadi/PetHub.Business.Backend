
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IProviderType_Service : IService<ProviderType>
{
    DataResult<List<Provider>> CollectionOfProvider(int provider_Id, Provider provider, UserCredit userCredit);
}
