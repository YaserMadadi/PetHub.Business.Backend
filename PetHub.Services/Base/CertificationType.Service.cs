
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

public class CertificationType_Service : Service<CertificationType>, ICertificationType_Service
{
    public CertificationType_Service() : base()
    {
    }

    public override async Task<DataResult<CertificationType>> SaveAttached(CertificationType certificationType, UserCredit userCredit)
    {
        return await certificationType.SaveAttached(userCredit);
    }

    public DataResult<List<Certification>> CollectionOfCertification(int certificationType_Id, Certification certification, UserCredit userCredit)
    {
        var procedureName = "[Base].[CertificationType.CollectionOfCertification]";

        return this.CollectionOf<Certification>(procedureName, 
                                                        new SqlParameter("@Id", certificationType_Id), 
                                                        new SqlParameter("@jsonValue", certification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
