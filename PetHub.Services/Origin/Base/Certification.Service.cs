
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

public class Certification_Service : Service<Certification>, ICertification_Service
{
    public Certification_Service() : base()
    {
    }

    public override async Task<DataResult<Certification>> SaveAttached(Certification certification, UserCredit userCredit)
    {
        return await certification.SaveAttached(userCredit);
    }

    public DataResult<List<ProviderCertification>> CollectionOfProviderCertification(int certification_Id, ProviderCertification providerCertification, UserCredit userCredit)
    {
        var procedureName = "[Base].[Certification.CollectionOfProviderCertification]";

        return this.CollectionOf<ProviderCertification>(procedureName, 
                                                        new SqlParameter("@Id", certification_Id), 
                                                        new SqlParameter("@jsonValue", providerCertification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
