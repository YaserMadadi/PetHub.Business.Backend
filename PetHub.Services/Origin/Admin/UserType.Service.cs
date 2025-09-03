
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
using PetHub.Entities.Base;

namespace PetHub.Services.Admin;

public class UserType_Service : Service<UserType>, IUserType_Service
{
    public UserType_Service() : base()
    {
    }

    public override async Task<DataResult<UserType>> SaveAttached(UserType userType, UserCredit userCredit)
    {
        return await userType.SaveAttached(userCredit);
    }

    public DataResult<List<Menu>> CollectionOfMenu(int userType_Id, Menu menu, UserCredit userCredit)
    {
        var procedureName = "[Admin].[UserType.CollectionOfMenu]";

        return this.CollectionOf<Menu>(procedureName, 
                                                        new SqlParameter("@Id", userType_Id), 
                                                        new SqlParameter("@jsonValue", menu.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<UserAccount>> CollectionOfUserAccount(int userType_Id, UserAccount userAccount, UserCredit userCredit)
    {
        var procedureName = "[Admin].[UserType.CollectionOfUserAccount]";

        return this.CollectionOf<UserAccount>(procedureName, 
                                                        new SqlParameter("@Id", userType_Id), 
                                                        new SqlParameter("@jsonValue", userAccount.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
