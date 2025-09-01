
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

public class CertIssuingOrganization_Service : Service<CertIssuingOrganization>, ICertIssuingOrganization_Service
{
    public CertIssuingOrganization_Service() : base()
    {
    }

    public override async Task<DataResult<CertIssuingOrganization>> SaveAttached(CertIssuingOrganization certIssuingOrganization, UserCredit userCredit)
    {
        return await certIssuingOrganization.SaveAttached(userCredit);
    }

    public DataResult<List<Certification>> CollectionOfCertification(int certIssuingOrganization_Id, Certification certification, UserCredit userCredit)
    {
        var procedureName = "[Base].[CertIssuingOrganization.CollectionOfCertification]";

        return this.CollectionOf<Certification>(procedureName, 
                                                        new SqlParameter("@Id", certIssuingOrganization_Id), 
                                                        new SqlParameter("@jsonValue", certification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
