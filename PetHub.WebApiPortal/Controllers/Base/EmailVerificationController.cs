
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Base;

namespace PetHub.ApiServices.Controllers.Base;

[Route("api/Base")]
public class EmailVerificationController : BaseController
{
    public EmailVerificationController(IEmailVerification_Service emailVerificationService)
    {
        this.emailVerificationService = emailVerificationService;
    }

    private IEmailVerification_Service emailVerificationService { get; set; }

    [HttpGet]
    [Route("EmailVerification/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.emailVerificationService.RetrieveById(id, EmailVerification.Informer, this.UserCredit);

        return result.ToActionResult<EmailVerification>();
    }

    [HttpGet]
    [Route("EmailVerification/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.emailVerificationService.RetrieveAll(EmailVerification.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<EmailVerification>();
    }
            

    
    [HttpPost]
    [Route("EmailVerification/Save")]
    public async Task<IActionResult> Save([FromBody] EmailVerification emailVerification)
    {
        var result = await this.emailVerificationService.Save(emailVerification, this.UserCredit);

        return result.ToActionResult<EmailVerification>();
    }

    
    [HttpPost]
    [Route("EmailVerification/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] EmailVerification emailVerification)
    {
        var result = await this.emailVerificationService.SaveAttached(emailVerification, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("EmailVerification/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<EmailVerification> emailVerificationList)
    {
        var result = await this.emailVerificationService.SaveBulk(emailVerificationList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("EmailVerification/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] EmailVerification emailVerification, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.emailVerificationService.Seek(emailVerification, this.UserCredit, pageNumber);

        return result.ToActionResult<EmailVerification>();
    }

    [HttpGet]
    [Route("EmailVerification/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.emailVerificationService.SeekByValue(seekValue, EmailVerification.Informer);

        return result.ToActionResult<EmailVerification>();
    }

    [HttpDelete]
    [Route("EmailVerification/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EmailVerification emailVerification)
    {
        var result = await this.emailVerificationService.Delete(emailVerification, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
