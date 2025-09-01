
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
public class PhoneNumberVerificationController : BaseController
{
    public PhoneNumberVerificationController(IPhoneNumberVerification_Service phoneNumberVerificationService)
    {
        this.phoneNumberVerificationService = phoneNumberVerificationService;
    }

    private IPhoneNumberVerification_Service phoneNumberVerificationService { get; set; }

    [HttpGet]
    [Route("PhoneNumberVerification/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.phoneNumberVerificationService.RetrieveById(id, PhoneNumberVerification.Informer, this.UserCredit);

        return result.ToActionResult<PhoneNumberVerification>();
    }

    [HttpGet]
    [Route("PhoneNumberVerification/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.phoneNumberVerificationService.RetrieveAll(PhoneNumberVerification.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<PhoneNumberVerification>();
    }
            

    
    [HttpPost]
    [Route("PhoneNumberVerification/Save")]
    public async Task<IActionResult> Save([FromBody] PhoneNumberVerification phoneNumberVerification)
    {
        var result = await this.phoneNumberVerificationService.Save(phoneNumberVerification, this.UserCredit);

        return result.ToActionResult<PhoneNumberVerification>();
    }

    
    [HttpPost]
    [Route("PhoneNumberVerification/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] PhoneNumberVerification phoneNumberVerification)
    {
        var result = await this.phoneNumberVerificationService.SaveAttached(phoneNumberVerification, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("PhoneNumberVerification/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<PhoneNumberVerification> phoneNumberVerificationList)
    {
        var result = await this.phoneNumberVerificationService.SaveBulk(phoneNumberVerificationList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("PhoneNumberVerification/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] PhoneNumberVerification phoneNumberVerification, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.phoneNumberVerificationService.Seek(phoneNumberVerification, this.UserCredit, pageNumber);

        return result.ToActionResult<PhoneNumberVerification>();
    }

    [HttpGet]
    [Route("PhoneNumberVerification/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.phoneNumberVerificationService.SeekByValue(seekValue, PhoneNumberVerification.Informer);

        return result.ToActionResult<PhoneNumberVerification>();
    }

    [HttpDelete]
    [Route("PhoneNumberVerification/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PhoneNumberVerification phoneNumberVerification)
    {
        var result = await this.phoneNumberVerificationService.Delete(phoneNumberVerification, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
