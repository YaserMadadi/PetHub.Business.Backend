using EssentialCore.Entities.Core;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using baseEntity = PetHub.Entities.Base;
using PetHub.Services.Base.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHub.Services.Extended.Security.Abstract;
public interface IAuthentication_Service : IUserAccount_Service
{
	public Task<DataResult<baseEntity.UserAccount>> Authenticate(UserAccount userAccount);

	public Task<Result> SignUp(UserAccount userAccount);

	public Task<Result> Verify(string email, string code);
}
