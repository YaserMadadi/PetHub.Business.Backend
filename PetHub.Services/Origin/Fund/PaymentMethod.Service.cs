
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

public class PaymentMethod_Service : Service<PaymentMethod>, IPaymentMethod_Service
{
    public PaymentMethod_Service() : base()
    {
    }

    public override async Task<DataResult<PaymentMethod>> SaveAttached(PaymentMethod paymentMethod, UserCredit userCredit)
    {
        return await paymentMethod.SaveAttached(userCredit);
    }

    public DataResult<List<WalletTopUp>> CollectionOfWalletTopUp(int paymentMethod_Id, WalletTopUp walletTopUp, UserCredit userCredit)
    {
        var procedureName = "[Fund].[PaymentMethod.CollectionOfWalletTopUp]";

        return this.CollectionOf<WalletTopUp>(procedureName, 
                                                        new SqlParameter("@Id", paymentMethod_Id), 
                                                        new SqlParameter("@jsonValue", walletTopUp.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
