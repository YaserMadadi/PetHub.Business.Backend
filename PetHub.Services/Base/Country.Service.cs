
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

public class Country_Service : Service<Country>, ICountry_Service
{
    public Country_Service() : base()
    {
    }

    public override async Task<DataResult<Country>> SaveAttached(Country country, UserCredit userCredit)
    {
        return await country.SaveAttached(userCredit);
    }

    public DataResult<List<Province>> CollectionOfProvince(int country_Id, Province province, UserCredit userCredit)
    {
        var procedureName = "[Base].[Country.CollectionOfProvince]";

        return this.CollectionOf<Province>(procedureName, 
                                                        new SqlParameter("@Id", country_Id), 
                                                        new SqlParameter("@jsonValue", province.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
