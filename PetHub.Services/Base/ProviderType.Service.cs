
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

public class ProviderType_Service : Service<ProviderType>, IProviderType_Service
{
    public ProviderType_Service() : base()
    {
    }

    public override async Task<DataResult<ProviderType>> SaveAttached(ProviderType providerType, UserCredit userCredit)
    {
        return await providerType.SaveAttached(userCredit);
    }

    public DataResult<List<Provider>> CollectionOfProvider(int providerType_Id, Provider provider, UserCredit userCredit)
    {
        var procedureName = "[Base].[ProviderType.CollectionOfProvider]";

        return this.CollectionOf<Provider>(procedureName, 
                                                        new SqlParameter("@Id", providerType_Id), 
                                                        new SqlParameter("@jsonValue", provider.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
