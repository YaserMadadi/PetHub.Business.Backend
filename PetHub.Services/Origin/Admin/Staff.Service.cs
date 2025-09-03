
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Admin;
using PetHub.Services.Admin.Actions;
using PetHub.Services.Admin.Abstract;

namespace PetHub.Services.Admin;

public class Staff_Service : Service<Staff>, IStaff_Service
{
    public Staff_Service() : base()
    {
    }

    public override async Task<DataResult<Staff>> SaveAttached(Staff staff, UserCredit userCredit)
    {
        return await staff.SaveAttached(userCredit);
    }

    public DataResult<List<StaffPermission>> CollectionOfStaffPermission(int staff_Id, StaffPermission staffPermission, UserCredit userCredit)
    {
        var procedureName = "[Admin].[Staff.CollectionOfStaffPermission]";

        return this.CollectionOf<StaffPermission>(procedureName, 
                                                        new SqlParameter("@Id", staff_Id), 
                                                        new SqlParameter("@jsonValue", staffPermission.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
