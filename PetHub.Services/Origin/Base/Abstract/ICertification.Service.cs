
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface ICertification_Service : IService<Certification>
{
    DataResult<List<ProviderCertification>> CollectionOfProviderCertification(int providerCertification_Id, ProviderCertification providerCertification, UserCredit userCredit);
}
