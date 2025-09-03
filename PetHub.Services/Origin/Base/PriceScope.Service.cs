
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

public class PriceScope_Service : Service<PriceScope>, IPriceScope_Service
{
    public PriceScope_Service() : base()
    {
    }

    public override async Task<DataResult<PriceScope>> SaveAttached(PriceScope priceScope, UserCredit userCredit)
    {
        return await priceScope.SaveAttached(userCredit);
    }

    public DataResult<List<ServicePrice>> CollectionOfServicePrice(int priceScope_Id, ServicePrice servicePrice, UserCredit userCredit)
    {
        var procedureName = "[Base].[PriceScope.CollectionOfServicePrice]";

        return this.CollectionOf<ServicePrice>(procedureName, 
                                                        new SqlParameter("@Id", priceScope_Id), 
                                                        new SqlParameter("@jsonValue", servicePrice.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
