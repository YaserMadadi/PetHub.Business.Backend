
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IWeekDay_Service : IService<WeekDay>
{
    DataResult<List<ServiceOrientedWorkTime>> CollectionOfServiceOrientedWorkTime(int serviceOrientedWorkTime_Id, ServiceOrientedWorkTime serviceOrientedWorkTime, UserCredit userCredit);

	DataResult<List<WorkTime>> CollectionOfWorkTime(int workTime_Id, WorkTime workTime, UserCredit userCredit);
}
