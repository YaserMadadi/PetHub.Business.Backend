
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

public class EmailVerification_Service : Service<EmailVerification>, IEmailVerification_Service
{
    public EmailVerification_Service() : base()
    {
    }

    public override async Task<DataResult<EmailVerification>> SaveAttached(EmailVerification emailVerification, UserCredit userCredit)
    {
        return await emailVerification.SaveAttached(userCredit);
    }

    
}
