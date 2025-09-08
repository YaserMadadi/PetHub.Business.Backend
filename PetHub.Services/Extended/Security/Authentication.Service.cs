using EssentialCore.DataAccess;
using EssentialCore.Entities.Core;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Services.Base;
using PetHub.Services.Extended.Security.Abstract;
using baseEntity = PetHub.Entities.Base;
using Microsoft.Data.SqlClient;

namespace PetHub.Services.Extended.Security;
public class Authentication_Service : UserAccount_Service, IAuthentication_Service
{
	public async Task<Result> SignUp(UserAccount userAccount)
	{
		 var command = UserClass.CreateCommand("[Kernel].[UserAccount.SignUp]",
								new SqlParameter("@Email", userAccount.Email),
								new SqlParameter("@Password", userAccount.Password),
								new SqlParameter("@UserType_Id", userAccount.UserType_Id));
		 
		var result = await command.ExecuteResult();

		if (!result.IsSucceeded)

			return new ErrorResult(result.Id, result.Message, result.OriginalMessage);

		return new SuccessfulResult(result.Id, result.Message);
	}

	public async Task<DataResult<baseEntity.UserAccount>> Authenticate(UserAccount userAccount)
	{
		var command = UserClass.CreateCommand("[Kernel].[User.Authenticate]",
								new SqlParameter("@Email", userAccount.Email),
								new SqlParameter("@Password", userAccount.Password));
								//new Microsoft.Data.SqlClient.SqlParameter("@UserType_Id", userAccount.UserType_Id));

		var result = await command.ExecuteResult();

		if (result.IsSucceeded)
		{
			return await this.RetrieveById(result.Id, baseEntity.UserAccount.Informer, new UserCredit() { UserAccount_Id = result.Id });
		}
			
		return new ErrorDataResult<baseEntity.UserAccount>(result.Id, result.Message);
	}

	public async Task<Result> Verify(string email, string code)
	{
		var command = UserClass.CreateCommand("[Kernel].[UserAccount.Verify]",
								new SqlParameter("@Email", email),
								new	SqlParameter("@Code", code));

		var result = await command.ExecuteResult();

		if (!result.IsSucceeded)

			return new ErrorResult(result.Id, result.Message, result.OriginalMessage);

		return new SuccessfulResult(result.Id, result.Message);
	}
}
