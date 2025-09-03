
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

public class Province_Service : Service<Province>, IProvince_Service
{
    public Province_Service() : base()
    {
    }

    public override async Task<DataResult<Province>> SaveAttached(Province province, UserCredit userCredit)
    {
        return await province.SaveAttached(userCredit);
    }

    public DataResult<List<City>> CollectionOfCity(int province_Id, City city, UserCredit userCredit)
    {
        var procedureName = "[Base].[Province.CollectionOfCity]";

        return this.CollectionOf<City>(procedureName, 
                                                        new SqlParameter("@Id", province_Id), 
                                                        new SqlParameter("@jsonValue", city.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
