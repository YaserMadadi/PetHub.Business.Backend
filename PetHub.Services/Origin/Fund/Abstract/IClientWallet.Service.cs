
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Fund;

namespace PetHub.Services.Fund.Abstract;

public interface IClientWallet_Service : IService<ClientWallet>
{
    DataResult<List<BookingTransaction>> CollectionOfBookingTransaction(int bookingTransaction_Id, BookingTransaction bookingTransaction, UserCredit userCredit);

	DataResult<List<ClientWalletTransactionLog>> CollectionOfClientWalletTransactionLog(int clientWalletTransactionLog_Id, ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit);

	DataResult<List<WalletTopUp>> CollectionOfWalletTopUp(int walletTopUp_Id, WalletTopUp walletTopUp, UserCredit userCredit);
}
