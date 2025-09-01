
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IBackgroundCheckStatus_Service : IService<BackgroundCheckStatus>
{
    DataResult<List<IndividualProvider>> CollectionOfIndividualProvider(int individualProvider_Id, IndividualProvider individualProvider, UserCredit userCredit);
}
