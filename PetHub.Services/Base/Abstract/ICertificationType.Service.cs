
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface ICertificationType_Service : IService<CertificationType>
{
    DataResult<List<Certification>> CollectionOfCertification(int certification_Id, Certification certification, UserCredit userCredit);
}
