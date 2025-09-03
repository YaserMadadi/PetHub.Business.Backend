
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Infra;
using PetHub.Services.Infra.Actions;
using PetHub.Services.Infra.Abstract;

namespace PetHub.Services.Infra;

public class RecordLog_Service : Service<RecordLog>, IRecordLog_Service
{
    public RecordLog_Service() : base()
    {
    }

    public override async Task<DataResult<RecordLog>> SaveAttached(RecordLog recordLog, UserCredit userCredit)
    {
        return await recordLog.SaveAttached(userCredit);
    }

    
}
