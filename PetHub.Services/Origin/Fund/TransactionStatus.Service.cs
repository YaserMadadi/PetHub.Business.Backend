
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

public class TransactionStatus_Service : Service<TransactionStatus>, ITransactionStatus_Service
{
    public TransactionStatus_Service() : base()
    {
    }

    public override async Task<DataResult<TransactionStatus>> SaveAttached(TransactionStatus transactionStatus, UserCredit userCredit)
    {
        return await transactionStatus.SaveAttached(userCredit);
    }

    public DataResult<List<ClientWalletTransactionLog>> CollectionOfClientWalletTransactionLog(int transactionStatus_Id, ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit)
    {
        var procedureName = "[Fund].[TransactionStatus.CollectionOfClientWalletTransactionLog]";

        return this.CollectionOf<ClientWalletTransactionLog>(procedureName, 
                                                        new SqlParameter("@Id", transactionStatus_Id), 
                                                        new SqlParameter("@jsonValue", clientWalletTransactionLog.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ProviderPayOut>> CollectionOfProviderPayOut(int transactionStatus_Id, ProviderPayOut providerPayOut, UserCredit userCredit)
    {
        var procedureName = "[Fund].[TransactionStatus.CollectionOfProviderPayOut]";

        return this.CollectionOf<ProviderPayOut>(procedureName, 
                                                        new SqlParameter("@Id", transactionStatus_Id), 
                                                        new SqlParameter("@jsonValue", providerPayOut.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<WalletTopUp>> CollectionOfWalletTopUp(int transactionStatus_Id, WalletTopUp walletTopUp, UserCredit userCredit)
    {
        var procedureName = "[Fund].[TransactionStatus.CollectionOfWalletTopUp]";

        return this.CollectionOf<WalletTopUp>(procedureName, 
                                                        new SqlParameter("@Id", transactionStatus_Id), 
                                                        new SqlParameter("@jsonValue", walletTopUp.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
