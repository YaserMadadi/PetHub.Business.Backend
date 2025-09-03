
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

public class ClientWallet_Service : Service<ClientWallet>, IClientWallet_Service
{
    public ClientWallet_Service() : base()
    {
    }

    public override async Task<DataResult<ClientWallet>> SaveAttached(ClientWallet clientWallet, UserCredit userCredit)
    {
        return await clientWallet.SaveAttached(userCredit);
    }

    public DataResult<List<BookingTransaction>> CollectionOfBookingTransaction(int clientWallet_Id, BookingTransaction bookingTransaction, UserCredit userCredit)
    {
        var procedureName = "[Fund].[ClientWallet.CollectionOfBookingTransaction]";

        return this.CollectionOf<BookingTransaction>(procedureName, 
                                                        new SqlParameter("@Id", clientWallet_Id), 
                                                        new SqlParameter("@jsonValue", bookingTransaction.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ClientWalletTransactionLog>> CollectionOfClientWalletTransactionLog(int clientWallet_Id, ClientWalletTransactionLog clientWalletTransactionLog, UserCredit userCredit)
    {
        var procedureName = "[Fund].[ClientWallet.CollectionOfClientWalletTransactionLog]";

        return this.CollectionOf<ClientWalletTransactionLog>(procedureName, 
                                                        new SqlParameter("@Id", clientWallet_Id), 
                                                        new SqlParameter("@jsonValue", clientWalletTransactionLog.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<WalletTopUp>> CollectionOfWalletTopUp(int clientWallet_Id, WalletTopUp walletTopUp, UserCredit userCredit)
    {
        var procedureName = "[Fund].[ClientWallet.CollectionOfWalletTopUp]";

        return this.CollectionOf<WalletTopUp>(procedureName, 
                                                        new SqlParameter("@Id", clientWallet_Id), 
                                                        new SqlParameter("@jsonValue", walletTopUp.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
