
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Fund;

namespace PetHub.Services.Fund.Abstract;

public interface ITransactionType_Service : IService<TransactionType>
{
    DataResult<List<ClientWalletTransactionLog>> CollectionOfClientWalletTransactionLog(int clientWalletTransactionLog_Id, ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit);
}
