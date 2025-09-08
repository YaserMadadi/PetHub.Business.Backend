using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PetHub.WebApiPortal.Controllers;
[Route("api")]
public class HomeController : Controller
{
	[HttpGet("Check")]
	public IActionResult Check()
	{
		return Ok("Hi there");
	}
}
