
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IPriceScope_Service : IService<PriceScope>
{
    DataResult<List<ServicePrice>> CollectionOfServicePrice(int servicePrice_Id, ServicePrice servicePrice, UserCredit userCredit);
}
