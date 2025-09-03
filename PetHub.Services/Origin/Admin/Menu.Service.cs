
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Admin;
using PetHub.Services.Admin.Actions;
using PetHub.Services.Admin.Abstract;

namespace PetHub.Services.Admin;

public class Menu_Service : Service<Menu>, IMenu_Service
{
    public Menu_Service() : base()
    {
    }

    public override async Task<DataResult<Menu>> SaveAttached(Menu menu, UserCredit userCredit)
    {
        return await menu.SaveAttached(userCredit);
    }

    public DataResult<List<MenuItem>> CollectionOfMenuItem(int menu_Id, MenuItem menuItem, UserCredit userCredit)
    {
        var procedureName = "[Admin].[Menu.CollectionOfMenuItem]";

        return this.CollectionOf<MenuItem>(procedureName, 
                                                        new SqlParameter("@Id", menu_Id), 
                                                        new SqlParameter("@jsonValue", menuItem.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
