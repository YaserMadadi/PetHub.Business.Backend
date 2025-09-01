
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

public class ConnectionType_Service : Service<ConnectionType>, IConnectionType_Service
{
    public ConnectionType_Service() : base()
    {
    }

    public override async Task<DataResult<ConnectionType>> SaveAttached(ConnectionType connectionType, UserCredit userCredit)
    {
        return await connectionType.SaveAttached(userCredit);
    }

    public DataResult<List<ProviderConnection>> CollectionOfProviderConnection(int connectionType_Id, ProviderConnection providerConnection, UserCredit userCredit)
    {
        var procedureName = "[Base].[ConnectionType.CollectionOfProviderConnection]";

        return this.CollectionOf<ProviderConnection>(procedureName, 
                                                        new SqlParameter("@Id", connectionType_Id), 
                                                        new SqlParameter("@jsonValue", providerConnection.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
