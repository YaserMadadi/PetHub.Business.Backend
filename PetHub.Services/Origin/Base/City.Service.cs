
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Base;
using PetHub.Services.Base.Actions;
using PetHub.Services.Base.Abstract;

namespace PetHub.Services.Base;

public class City_Service : Service<City>, ICity_Service
{
    public City_Service() : base()
    {
    }

    public override async Task<DataResult<City>> SaveAttached(City city, UserCredit userCredit)
    {
        return await city.SaveAttached(userCredit);
    }

    public DataResult<List<Client>> CollectionOfClient(int city_Id, Client client, UserCredit userCredit)
    {
        var procedureName = "[Base].[City.CollectionOfClient]";

        return this.CollectionOf<Client>(procedureName, 
                                                        new SqlParameter("@Id", city_Id), 
                                                        new SqlParameter("@jsonValue", client.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<LocationCoverage>> CollectionOfLocationCoverage(int city_Id, LocationCoverage locationCoverage, UserCredit userCredit)
    {
        var procedureName = "[Base].[City.CollectionOfLocationCoverage]";

        return this.CollectionOf<LocationCoverage>(procedureName, 
                                                        new SqlParameter("@Id", city_Id), 
                                                        new SqlParameter("@jsonValue", locationCoverage.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
