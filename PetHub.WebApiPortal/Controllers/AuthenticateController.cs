using EssentialCore.Controllers;
using EssentialCore.Tools.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using PetHub.Entities.Base;
using PetHub.Services.Base.Abstract;
using PetHub.Services.Extended.Security.Abstract;

namespace PetHub.WebApiPortal.Controllers;


[Route("api")]
public class AuthenticateController : BaseController
{

	public AuthenticateController(IAuthentication_Service authenticationService)
	{
		this.authenticationService = authenticationService;
	}

	private IAuthentication_Service authenticationService { get; set; }

	[HttpPost]
	[EnableRateLimiting("VerificationPolicy")]
	[Route("Signup")]
	public async Task<IActionResult> SignUp([FromBody] EssentialCore.Entities.Core.UserAccount userAccount)
	{
		var result = await this.authenticationService.SignUp(userAccount);

		return result.ToActionResult();
	}

	[HttpGet]
	[Route("Verify")]
	[EnableRateLimiting("VerificationPolicy")]
	public async Task<IActionResult> Verify([FromQuery] string email, [FromQuery] string code)
	{
		var result = await this.authenticationService.Verify(email, code);

		return result.ToActionResult();
	}

	[HttpPost]
	[EnableRateLimiting("VerificationPolicy")]
	[Route("Authenticate")]
	public async Task<IActionResult> SignIn([FromBody] EssentialCore.Entities.Core.UserAccount userAccount)
	{
		var result = await this.authenticationService.Authenticate(userAccount);

		return result.ToActionResult();
	}
}
