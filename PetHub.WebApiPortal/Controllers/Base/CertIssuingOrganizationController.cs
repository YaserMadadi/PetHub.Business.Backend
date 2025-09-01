
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
public class CertIssuingOrganizationController : BaseController
{
    public CertIssuingOrganizationController(ICertIssuingOrganization_Service certIssuingOrganizationService)
    {
        this.certIssuingOrganizationService = certIssuingOrganizationService;
    }

    private ICertIssuingOrganization_Service certIssuingOrganizationService { get; set; }

    [HttpGet]
    [Route("CertIssuingOrganization/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.certIssuingOrganizationService.RetrieveById(id, CertIssuingOrganization.Informer, this.UserCredit);

        return result.ToActionResult<CertIssuingOrganization>();
    }

    [HttpGet]
    [Route("CertIssuingOrganization/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.certIssuingOrganizationService.RetrieveAll(CertIssuingOrganization.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<CertIssuingOrganization>();
    }
            

    
    [HttpPost]
    [Route("CertIssuingOrganization/Save")]
    public async Task<IActionResult> Save([FromBody] CertIssuingOrganization certIssuingOrganization)
    {
        var result = await this.certIssuingOrganizationService.Save(certIssuingOrganization, this.UserCredit);

        return result.ToActionResult<CertIssuingOrganization>();
    }

    
    [HttpPost]
    [Route("CertIssuingOrganization/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] CertIssuingOrganization certIssuingOrganization)
    {
        var result = await this.certIssuingOrganizationService.SaveAttached(certIssuingOrganization, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("CertIssuingOrganization/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<CertIssuingOrganization> certIssuingOrganizationList)
    {
        var result = await this.certIssuingOrganizationService.SaveBulk(certIssuingOrganizationList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("CertIssuingOrganization/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] CertIssuingOrganization certIssuingOrganization, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.certIssuingOrganizationService.Seek(certIssuingOrganization, this.UserCredit, pageNumber);

        return result.ToActionResult<CertIssuingOrganization>();
    }

    [HttpGet]
    [Route("CertIssuingOrganization/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.certIssuingOrganizationService.SeekByValue(seekValue, CertIssuingOrganization.Informer);

        return result.ToActionResult<CertIssuingOrganization>();
    }

    [HttpDelete]
    [Route("CertIssuingOrganization/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CertIssuingOrganization certIssuingOrganization)
    {
        var result = await this.certIssuingOrganizationService.Delete(certIssuingOrganization, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// CertIssuingOrganization.CollectionOfCertification
    [HttpPost]
    [Route("CertIssuingOrganization/{certIssuingOrganization_id:int}/Certification")]
    public IActionResult CollectionOfCertification([FromRoute(Name = "certIssuingOrganization_id")] int id, [FromBody] Certification certification)
    {
        return this.certIssuingOrganizationService.CollectionOfCertification(id, certification, this.UserCredit).ToActionResult();
    }
}
