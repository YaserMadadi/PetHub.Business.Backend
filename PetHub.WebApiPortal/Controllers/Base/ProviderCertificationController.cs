
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
public class ProviderCertificationController : BaseController
{
    public ProviderCertificationController(IProviderCertification_Service providerCertificationService)
    {
        this.providerCertificationService = providerCertificationService;
    }

    private IProviderCertification_Service providerCertificationService { get; set; }

    [HttpGet]
    [Route("ProviderCertification/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerCertificationService.RetrieveById(id, ProviderCertification.Informer, this.UserCredit);

        return result.ToActionResult<ProviderCertification>();
    }

    [HttpGet]
    [Route("ProviderCertification/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerCertificationService.RetrieveAll(ProviderCertification.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ProviderCertification>();
    }
            

    
    [HttpPost]
    [Route("ProviderCertification/Save")]
    public async Task<IActionResult> Save([FromBody] ProviderCertification providerCertification)
    {
        var result = await this.providerCertificationService.Save(providerCertification, this.UserCredit);

        return result.ToActionResult<ProviderCertification>();
    }

    
    [HttpPost]
    [Route("ProviderCertification/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ProviderCertification providerCertification)
    {
        var result = await this.providerCertificationService.SaveAttached(providerCertification, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ProviderCertification/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ProviderCertification> providerCertificationList)
    {
        var result = await this.providerCertificationService.SaveBulk(providerCertificationList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ProviderCertification/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ProviderCertification providerCertification, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerCertificationService.Seek(providerCertification, this.UserCredit, pageNumber);

        return result.ToActionResult<ProviderCertification>();
    }

    [HttpGet]
    [Route("ProviderCertification/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerCertificationService.SeekByValue(seekValue, ProviderCertification.Informer);

        return result.ToActionResult<ProviderCertification>();
    }

    [HttpDelete]
    [Route("ProviderCertification/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ProviderCertification providerCertification)
    {
        var result = await this.providerCertificationService.Delete(providerCertification, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
