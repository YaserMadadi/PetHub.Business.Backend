
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Fund;
using PetHub.Services.Fund.Actions;
using PetHub.Services.Fund.Abstract;

namespace PetHub.Services.Fund;

public class ClientWalletTransactionLog_Service : Service<ClientWalletTransactionLog>, IClientWalletTransactionLog_Service
{
    public ClientWalletTransactionLog_Service() : base()
    {
    }

    public override async Task<DataResult<ClientWalletTransactionLog>> SaveAttached(ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit)
    {
        return await clientWalletTransactionLog.SaveAttached(userCredit);
    }

    
}
