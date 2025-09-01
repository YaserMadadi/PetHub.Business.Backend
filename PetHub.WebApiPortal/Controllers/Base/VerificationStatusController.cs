
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
public class VerificationStatusController : BaseController
{
    public VerificationStatusController(IVerificationStatus_Service verificationStatusService)
    {
        this.verificationStatusService = verificationStatusService;
    }

    private IVerificationStatus_Service verificationStatusService { get; set; }

    [HttpGet]
    [Route("VerificationStatus/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.verificationStatusService.RetrieveById(id, VerificationStatus.Informer, this.UserCredit);

        return result.ToActionResult<VerificationStatus>();
    }

    [HttpGet]
    [Route("VerificationStatus/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.verificationStatusService.RetrieveAll(VerificationStatus.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<VerificationStatus>();
    }
            

    
    [HttpPost]
    [Route("VerificationStatus/Save")]
    public async Task<IActionResult> Save([FromBody] VerificationStatus verificationStatus)
    {
        var result = await this.verificationStatusService.Save(verificationStatus, this.UserCredit);

        return result.ToActionResult<VerificationStatus>();
    }

    
    [HttpPost]
    [Route("VerificationStatus/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] VerificationStatus verificationStatus)
    {
        var result = await this.verificationStatusService.SaveAttached(verificationStatus, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("VerificationStatus/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<VerificationStatus> verificationStatusList)
    {
        var result = await this.verificationStatusService.SaveBulk(verificationStatusList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("VerificationStatus/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] VerificationStatus verificationStatus, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.verificationStatusService.Seek(verificationStatus, this.UserCredit, pageNumber);

        return result.ToActionResult<VerificationStatus>();
    }

    [HttpGet]
    [Route("VerificationStatus/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.verificationStatusService.SeekByValue(seekValue, VerificationStatus.Informer);

        return result.ToActionResult<VerificationStatus>();
    }

    [HttpDelete]
    [Route("VerificationStatus/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] VerificationStatus verificationStatus)
    {
        var result = await this.verificationStatusService.Delete(verificationStatus, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// VerificationStatus.CollectionOfClient
    [HttpPost]
    [Route("VerificationStatus/{verificationStatus_id:int}/Client")]
    public IActionResult CollectionOfClient([FromRoute(Name = "verificationStatus_id")] int id, [FromBody] Client client)
    {
        return this.verificationStatusService.CollectionOfClient(id, client, this.UserCredit).ToActionResult();
    }

		//// VerificationStatus.CollectionOfEmailVerification
    [HttpPost]
    [Route("VerificationStatus/{verificationStatus_id:int}/EmailVerification")]
    public IActionResult CollectionOfEmailVerification([FromRoute(Name = "verificationStatus_id")] int id, [FromBody] EmailVerification emailVerification)
    {
        return this.verificationStatusService.CollectionOfEmailVerification(id, emailVerification, this.UserCredit).ToActionResult();
    }

		//// VerificationStatus.CollectionOfPhoneNumberVerification
    [HttpPost]
    [Route("VerificationStatus/{verificationStatus_id:int}/PhoneNumberVerification")]
    public IActionResult CollectionOfPhoneNumberVerification([FromRoute(Name = "verificationStatus_id")] int id, [FromBody] PhoneNumberVerification phoneNumberVerification)
    {
        return this.verificationStatusService.CollectionOfPhoneNumberVerification(id, phoneNumberVerification, this.UserCredit).ToActionResult();
    }
}
