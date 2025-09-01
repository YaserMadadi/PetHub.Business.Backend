
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

public class WalletTopUp_Service : Service<WalletTopUp>, IWalletTopUp_Service
{
    public WalletTopUp_Service() : base()
    {
    }

    public override async Task<DataResult<WalletTopUp>> SaveAttached(WalletTopUp walletTopUp, UserCredit userCredit)
    {
        return await walletTopUp.SaveAttached(userCredit);
    }

    
}
