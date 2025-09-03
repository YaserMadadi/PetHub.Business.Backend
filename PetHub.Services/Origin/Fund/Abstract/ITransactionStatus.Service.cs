
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Fund;

namespace PetHub.Services.Fund.Abstract;

public interface ITransactionStatus_Service : IService<TransactionStatus>
{
    DataResult<List<ClientWalletTransactionLog>> CollectionOfClientWalletTransactionLog(int clientWalletTransactionLog_Id, ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit);

	DataResult<List<ProviderPayOut>> CollectionOfProviderPayOut(int providerPayOut_Id, ProviderPayOut providerPayOut, UserCredit userCredit);

	DataResult<List<WalletTopUp>> CollectionOfWalletTopUp(int walletTopUp_Id, WalletTopUp walletTopUp, UserCredit userCredit);
}
