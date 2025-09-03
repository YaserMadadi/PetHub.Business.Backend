
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

public class ProviderWallet_Service : Service<ProviderWallet>, IProviderWallet_Service
{
    public ProviderWallet_Service() : base()
    {
    }

    public override async Task<DataResult<ProviderWallet>> SaveAttached(ProviderWallet providerWallet, UserCredit userCredit)
    {
        return await providerWallet.SaveAttached(userCredit);
    }

    public DataResult<List<BookingTransaction>> CollectionOfBookingTransaction(int providerWallet_Id, BookingTransaction bookingTransaction, UserCredit userCredit)
    {
        var procedureName = "[Fund].[ProviderWallet.CollectionOfBookingTransaction]";

        return this.CollectionOf<BookingTransaction>(procedureName, 
                                                        new SqlParameter("@Id", providerWallet_Id), 
                                                        new SqlParameter("@jsonValue", bookingTransaction.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
