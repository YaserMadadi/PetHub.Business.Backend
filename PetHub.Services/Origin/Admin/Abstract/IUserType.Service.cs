
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Admin;
using PetHub.Entities.Base;

namespace PetHub.Services.Admin.Abstract;

public interface IUserType_Service : IService<UserType>
{
    DataResult<List<Menu>> CollectionOfMenu(int menu_Id, Menu menu, UserCredit userCredit);

	DataResult<List<UserAccount>> CollectionOfUserAccount(int userAccount_Id, UserAccount userAccount, UserCredit userCredit);
}
