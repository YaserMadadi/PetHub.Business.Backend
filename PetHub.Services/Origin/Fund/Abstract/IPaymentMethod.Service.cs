
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Fund;

namespace PetHub.Services.Fund.Abstract;

public interface IPaymentMethod_Service : IService<PaymentMethod>
{
    DataResult<List<WalletTopUp>> CollectionOfWalletTopUp(int walletTopUp_Id, WalletTopUp walletTopUp, UserCredit userCredit);
}
