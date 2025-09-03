using EssentialCore.DataAccess;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Serializer;
using Microsoft.Data.SqlClient;
using PetHub.Entities.Admin;
using PetHub.Services.Extended.Admin.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHub.Services.Extended.Admin;
public class Menu_ExtendedService : IMenu_ExtendedService
{
	public async Task<DataResult<List<Menu>>> LoadMenu(int userType_Id, UserCredit userCredit)
	{
		var procedureName = "[Admin].[Menu.LoadByUserType]";

		var command = UserClass.CreateCommand(procedureName,
										new SqlParameter("@UserType_Id", userType_Id),
										new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));

		var result = await command.ExecuteDataResult<List<Menu>>(JsonType.Collection);

		return result;
	}
}
