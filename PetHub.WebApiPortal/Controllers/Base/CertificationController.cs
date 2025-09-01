
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
public class CertificationController : BaseController
{
    public CertificationController(ICertification_Service certificationService)
    {
        this.certificationService = certificationService;
    }

    private ICertification_Service certificationService { get; set; }

    [HttpGet]
    [Route("Certification/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.certificationService.RetrieveById(id, Certification.Informer, this.UserCredit);

        return result.ToActionResult<Certification>();
    }

    [HttpGet]
    [Route("Certification/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.certificationService.RetrieveAll(Certification.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Certification>();
    }
            

    
    [HttpPost]
    [Route("Certification/Save")]
    public async Task<IActionResult> Save([FromBody] Certification certification)
    {
        var result = await this.certificationService.Save(certification, this.UserCredit);

        return result.ToActionResult<Certification>();
    }

    
    [HttpPost]
    [Route("Certification/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Certification certification)
    {
        var result = await this.certificationService.SaveAttached(certification, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Certification/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Certification> certificationList)
    {
        var result = await this.certificationService.SaveBulk(certificationList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Certification/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Certification certification, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.certificationService.Seek(certification, this.UserCredit, pageNumber);

        return result.ToActionResult<Certification>();
    }

    [HttpGet]
    [Route("Certification/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.certificationService.SeekByValue(seekValue, Certification.Informer);

        return result.ToActionResult<Certification>();
    }

    [HttpDelete]
    [Route("Certification/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Certification certification)
    {
        var result = await this.certificationService.Delete(certification, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Certification.CollectionOfProviderCertification
    [HttpPost]
    [Route("Certification/{certification_id:int}/ProviderCertification")]
    public IActionResult CollectionOfProviderCertification([FromRoute(Name = "certification_id")] int id, [FromBody] ProviderCertification providerCertification)
    {
        return this.certificationService.CollectionOfProviderCertification(id, providerCertification, this.UserCredit).ToActionResult();
    }
}
