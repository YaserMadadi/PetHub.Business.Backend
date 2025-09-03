
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

public class Bank_Service : Service<Bank>, IBank_Service
{
    public Bank_Service() : base()
    {
    }

    public override async Task<DataResult<Bank>> SaveAttached(Bank bank, UserCredit userCredit)
    {
        return await bank.SaveAttached(userCredit);
    }

    public DataResult<List<ProviderBankAccount>> CollectionOfProviderBankAccount(int bank_Id, ProviderBankAccount providerBankAccount, UserCredit userCredit)
    {
        var procedureName = "[Base].[Bank.CollectionOfProviderBankAccount]";

        return this.CollectionOf<ProviderBankAccount>(procedureName, 
                                                        new SqlParameter("@Id", bank_Id), 
                                                        new SqlParameter("@jsonValue", providerBankAccount.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
