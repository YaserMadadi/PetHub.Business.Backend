
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

public class WorkTime_Service : Service<WorkTime>, IWorkTime_Service
{
    public WorkTime_Service() : base()
    {
    }

    public override async Task<DataResult<WorkTime>> SaveAttached(WorkTime workTime, UserCredit userCredit)
    {
        return await workTime.SaveAttached(userCredit);
    }

    
}
