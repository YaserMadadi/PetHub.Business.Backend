
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Base;
using PetHub.Services.Base.Actions;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Admin;

namespace PetHub.Services.Base;

public class UserAccount_Service : Service<UserAccount>, IUserAccount_Service
{
    public UserAccount_Service() : base()
    {
    }

    public override async Task<DataResult<UserAccount>> SaveAttached(UserAccount userAccount, UserCredit userCredit)
    {
        return await userAccount.SaveAttached(userCredit);
    }

    public DataResult<List<Client>> CollectionOfClient(int userAccount_Id, Client client, UserCredit userCredit)
    {
        var procedureName = "[Base].[UserAccount.CollectionOfClient]";

        return this.CollectionOf<Client>(procedureName, 
                                                        new SqlParameter("@Id", userAccount_Id), 
                                                        new SqlParameter("@jsonValue", client.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<EmailVerification>> CollectionOfEmailVerification(int userAccount_Id, EmailVerification emailVerification, UserCredit userCredit)
    {
        var procedureName = "[Base].[UserAccount.CollectionOfEmailVerification]";

        return this.CollectionOf<EmailVerification>(procedureName, 
                                                        new SqlParameter("@Id", userAccount_Id), 
                                                        new SqlParameter("@jsonValue", emailVerification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<Provider>> CollectionOfProvider(int userAccount_Id, Provider provider, UserCredit userCredit)
    {
        var procedureName = "[Base].[UserAccount.CollectionOfProvider]";

        return this.CollectionOf<Provider>(procedureName, 
                                                        new SqlParameter("@Id", userAccount_Id), 
                                                        new SqlParameter("@jsonValue", provider.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<RoleMember>> CollectionOfRoleMember(int userAccount_Id, RoleMember roleMember, UserCredit userCredit)
    {
        var procedureName = "[Base].[UserAccount.CollectionOfRoleMember]";

        return this.CollectionOf<RoleMember>(procedureName, 
                                                        new SqlParameter("@Id", userAccount_Id), 
                                                        new SqlParameter("@jsonValue", roleMember.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<Staff>> CollectionOfStaff(int userAccount_Id, Staff staff, UserCredit userCredit)
    {
        var procedureName = "[Base].[UserAccount.CollectionOfStaff]";

        return this.CollectionOf<Staff>(procedureName, 
                                                        new SqlParameter("@Id", userAccount_Id), 
                                                        new SqlParameter("@jsonValue", staff.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
