
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

public class TransactionType_Service : Service<TransactionType>, ITransactionType_Service
{
    public TransactionType_Service() : base()
    {
    }

    public override async Task<DataResult<TransactionType>> SaveAttached(TransactionType transactionType, UserCredit userCredit)
    {
        return await transactionType.SaveAttached(userCredit);
    }

    public DataResult<List<ClientWalletTransactionLog>> CollectionOfClientWalletTransactionLog(int transactionType_Id, ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit)
    {
        var procedureName = "[Fund].[TransactionType.CollectionOfClientWalletTransactionLog]";

        return this.CollectionOf<ClientWalletTransactionLog>(procedureName, 
                                                        new SqlParameter("@Id", transactionType_Id), 
                                                        new SqlParameter("@jsonValue", clientWalletTransactionLog.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
