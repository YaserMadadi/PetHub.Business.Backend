
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface ICity_Service : IService<City>
{
    DataResult<List<Client>> CollectionOfClient(int client_Id, Client client, UserCredit userCredit);

	DataResult<List<LocationCoverage>> CollectionOfLocationCoverage(int locationCoverage_Id, LocationCoverage locationCoverage, UserCredit userCredit);
}
