
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IServiceType_Service : IService<ServiceType>
{
    DataResult<List<ProviderService>> CollectionOfProviderService(int providerService_Id, ProviderService providerService, UserCredit userCredit);
}
