
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Admin;

namespace PetHub.Services.Admin.Abstract;

public interface IMenu_Service : IService<Menu>
{
    DataResult<List<MenuItem>> CollectionOfMenuItem(int menuItem_Id, MenuItem menuItem, UserCredit userCredit);
}
