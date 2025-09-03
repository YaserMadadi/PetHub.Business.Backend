
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

public class ProviderBankAccount_Service : Service<ProviderBankAccount>, IProviderBankAccount_Service
{
    public ProviderBankAccount_Service() : base()
    {
    }

    public override async Task<DataResult<ProviderBankAccount>> SaveAttached(ProviderBankAccount providerBankAccount, UserCredit userCredit)
    {
        return await providerBankAccount.SaveAttached(userCredit);
    }

    
}
