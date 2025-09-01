
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

public class PhoneNumberVerification_Service : Service<PhoneNumberVerification>, IPhoneNumberVerification_Service
{
    public PhoneNumberVerification_Service() : base()
    {
    }

    public override async Task<DataResult<PhoneNumberVerification>> SaveAttached(PhoneNumberVerification phoneNumberVerification, UserCredit userCredit)
    {
        return await phoneNumberVerification.SaveAttached(userCredit);
    }

    
}
