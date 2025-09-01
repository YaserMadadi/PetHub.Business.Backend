
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
using PetHub.Entities.Fund;

namespace PetHub.Services.Base;

public class Client_Service : Service<Client>, IClient_Service
{
    public Client_Service() : base()
    {
    }

    public override async Task<DataResult<Client>> SaveAttached(Client client, UserCredit userCredit)
    {
        return await client.SaveAttached(userCredit);
    }

    public DataResult<List<ClientNotification>> CollectionOfClientNotification(int client_Id, ClientNotification clientNotification, UserCredit userCredit)
    {
        var procedureName = "[Base].[Client.CollectionOfClientNotification]";

        return this.CollectionOf<ClientNotification>(procedureName, 
                                                        new SqlParameter("@Id", client_Id), 
                                                        new SqlParameter("@jsonValue", clientNotification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ClientReview>> CollectionOfClientReview(int client_Id, ClientReview clientReview, UserCredit userCredit)
    {
        var procedureName = "[Base].[Client.CollectionOfClientReview]";

        return this.CollectionOf<ClientReview>(procedureName, 
                                                        new SqlParameter("@Id", client_Id), 
                                                        new SqlParameter("@jsonValue", clientReview.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ClientWallet>> CollectionOfClientWallet(int client_Id, ClientWallet clientWallet, UserCredit userCredit)
    {
        var procedureName = "[Base].[Client.CollectionOfClientWallet]";

        return this.CollectionOf<ClientWallet>(procedureName, 
                                                        new SqlParameter("@Id", client_Id), 
                                                        new SqlParameter("@jsonValue", clientWallet.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<Pet>> CollectionOfPet(int client_Id, Pet pet, UserCredit userCredit)
    {
        var procedureName = "[Base].[Client.CollectionOfPet]";

        return this.CollectionOf<Pet>(procedureName, 
                                                        new SqlParameter("@Id", client_Id), 
                                                        new SqlParameter("@jsonValue", pet.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<PhoneNumberVerification>> CollectionOfPhoneNumberVerification(int client_Id, PhoneNumberVerification phoneNumberVerification, UserCredit userCredit)
    {
        var procedureName = "[Base].[Client.CollectionOfPhoneNumberVerification]";

        return this.CollectionOf<PhoneNumberVerification>(procedureName, 
                                                        new SqlParameter("@Id", client_Id), 
                                                        new SqlParameter("@jsonValue", phoneNumberVerification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
