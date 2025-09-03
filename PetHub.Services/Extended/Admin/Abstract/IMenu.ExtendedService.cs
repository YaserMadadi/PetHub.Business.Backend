using EssentialCore.BusinessLogic;
using EssentialCore.DataAccess;
using EssentialCore.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Serializer;

namespace PetHub.Services.Extended.Admin.Abstract;

public interface IMenu_ExtendedService
{
	public Task<DataResult<List<Menu>>> LoadMenu(int userType_Id, UserCredit userCredit);
	
}
