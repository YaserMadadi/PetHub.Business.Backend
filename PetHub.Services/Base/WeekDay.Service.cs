
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

public class WeekDay_Service : Service<WeekDay>, IWeekDay_Service
{
    public WeekDay_Service() : base()
    {
    }

    public override async Task<DataResult<WeekDay>> SaveAttached(WeekDay weekDay, UserCredit userCredit)
    {
        return await weekDay.SaveAttached(userCredit);
    }

    public DataResult<List<ServiceOrientedWorkTime>> CollectionOfServiceOrientedWorkTime(int weekDay_Id, ServiceOrientedWorkTime serviceOrientedWorkTime, UserCredit userCredit)
    {
        var procedureName = "[Base].[WeekDay.CollectionOfServiceOrientedWorkTime]";

        return this.CollectionOf<ServiceOrientedWorkTime>(procedureName, 
                                                        new SqlParameter("@Id", weekDay_Id), 
                                                        new SqlParameter("@jsonValue", serviceOrientedWorkTime.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<WorkTime>> CollectionOfWorkTime(int weekDay_Id, WorkTime workTime, UserCredit userCredit)
    {
        var procedureName = "[Base].[WeekDay.CollectionOfWorkTime]";

        return this.CollectionOf<WorkTime>(procedureName, 
                                                        new SqlParameter("@Id", weekDay_Id), 
                                                        new SqlParameter("@jsonValue", workTime.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
