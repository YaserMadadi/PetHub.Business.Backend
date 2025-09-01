
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

namespace PetHub.Services.Base;

public class VerificationStatus_Service : Service<VerificationStatus>, IVerificationStatus_Service
{
    public VerificationStatus_Service() : base()
    {
    }

    public override async Task<DataResult<VerificationStatus>> SaveAttached(VerificationStatus verificationStatus, UserCredit userCredit)
    {
        return await verificationStatus.SaveAttached(userCredit);
    }

    public DataResult<List<Client>> CollectionOfClient(int verificationStatus_Id, Client client, UserCredit userCredit)
    {
        var procedureName = "[Base].[VerificationStatus.CollectionOfClient]";

        return this.CollectionOf<Client>(procedureName, 
                                                        new SqlParameter("@Id", verificationStatus_Id), 
                                                        new SqlParameter("@jsonValue", client.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<EmailVerification>> CollectionOfEmailVerification(int verificationStatus_Id, EmailVerification emailVerification, UserCredit userCredit)
    {
        var procedureName = "[Base].[VerificationStatus.CollectionOfEmailVerification]";

        return this.CollectionOf<EmailVerification>(procedureName, 
                                                        new SqlParameter("@Id", verificationStatus_Id), 
                                                        new SqlParameter("@jsonValue", emailVerification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<PhoneNumberVerification>> CollectionOfPhoneNumberVerification(int verificationStatus_Id, PhoneNumberVerification phoneNumberVerification, UserCredit userCredit)
    {
        var procedureName = "[Base].[VerificationStatus.CollectionOfPhoneNumberVerification]";

        return this.CollectionOf<PhoneNumberVerification>(procedureName, 
                                                        new SqlParameter("@Id", verificationStatus_Id), 
                                                        new SqlParameter("@jsonValue", phoneNumberVerification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
