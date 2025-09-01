
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

public class DurationUnit_Service : Service<DurationUnit>, IDurationUnit_Service
{
    public DurationUnit_Service() : base()
    {
    }

    public override async Task<DataResult<DurationUnit>> SaveAttached(DurationUnit durationUnit, UserCredit userCredit)
    {
        return await durationUnit.SaveAttached(userCredit);
    }

    public DataResult<List<Booking>> CollectionOfBooking(int durationUnit_Id, Booking booking, UserCredit userCredit)
    {
        var procedureName = "[Base].[DurationUnit.CollectionOfBooking]";

        return this.CollectionOf<Booking>(procedureName, 
                                                        new SqlParameter("@Id", durationUnit_Id), 
                                                        new SqlParameter("@jsonValue", booking.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
