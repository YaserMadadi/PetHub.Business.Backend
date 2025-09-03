
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

public class BackgroundCheckStatus_Service : Service<BackgroundCheckStatus>, IBackgroundCheckStatus_Service
{
    public BackgroundCheckStatus_Service() : base()
    {
    }

    public override async Task<DataResult<BackgroundCheckStatus>> SaveAttached(BackgroundCheckStatus backgroundCheckStatus, UserCredit userCredit)
    {
        return await backgroundCheckStatus.SaveAttached(userCredit);
    }

    public DataResult<List<IndividualProvider>> CollectionOfIndividualProvider(int backgroundCheckStatus_Id, IndividualProvider individualProvider, UserCredit userCredit)
    {
        var procedureName = "[Base].[BackgroundCheckStatus.CollectionOfIndividualProvider]";

        return this.CollectionOf<IndividualProvider>(procedureName, 
                                                        new SqlParameter("@Id", backgroundCheckStatus_Id), 
                                                        new SqlParameter("@jsonValue", individualProvider.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
