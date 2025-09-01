
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface ICountry_Service : IService<Country>
{
    DataResult<List<Province>> CollectionOfProvince(int province_Id, Province province, UserCredit userCredit);
}
