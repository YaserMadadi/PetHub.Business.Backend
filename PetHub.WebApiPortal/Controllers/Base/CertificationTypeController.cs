
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
public class CertificationTypeController : BaseController
{
    public CertificationTypeController(ICertificationType_Service certificationTypeService)
    {
        this.certificationTypeService = certificationTypeService;
    }

    private ICertificationType_Service certificationTypeService { get; set; }

    [HttpGet]
    [Route("CertificationType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.certificationTypeService.RetrieveById(id, CertificationType.Informer, this.UserCredit);

        return result.ToActionResult<CertificationType>();
    }

    [HttpGet]
    [Route("CertificationType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.certificationTypeService.RetrieveAll(CertificationType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<CertificationType>();
    }
            

    
    [HttpPost]
    [Route("CertificationType/Save")]
    public async Task<IActionResult> Save([FromBody] CertificationType certificationType)
    {
        var result = await this.certificationTypeService.Save(certificationType, this.UserCredit);

        return result.ToActionResult<CertificationType>();
    }

    
    [HttpPost]
    [Route("CertificationType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] CertificationType certificationType)
    {
        var result = await this.certificationTypeService.SaveAttached(certificationType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("CertificationType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<CertificationType> certificationTypeList)
    {
        var result = await this.certificationTypeService.SaveBulk(certificationTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("CertificationType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] CertificationType certificationType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.certificationTypeService.Seek(certificationType, this.UserCredit, pageNumber);

        return result.ToActionResult<CertificationType>();
    }

    [HttpGet]
    [Route("CertificationType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.certificationTypeService.SeekByValue(seekValue, CertificationType.Informer);

        return result.ToActionResult<CertificationType>();
    }

    [HttpDelete]
    [Route("CertificationType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CertificationType certificationType)
    {
        var result = await this.certificationTypeService.Delete(certificationType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// CertificationType.CollectionOfCertification
    [HttpPost]
    [Route("CertificationType/{certificationType_id:int}/Certification")]
    public IActionResult CollectionOfCertification([FromRoute(Name = "certificationType_id")] int id, [FromBody] Certification certification)
    {
        return this.certificationTypeService.CollectionOfCertification(id, certification, this.UserCredit).ToActionResult();
    }
}
