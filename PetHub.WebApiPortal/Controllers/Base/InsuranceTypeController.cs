
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
public class InsuranceTypeController : BaseController
{
    public InsuranceTypeController(IInsuranceType_Service insuranceTypeService)
    {
        this.insuranceTypeService = insuranceTypeService;
    }

    private IInsuranceType_Service insuranceTypeService { get; set; }

    [HttpGet]
    [Route("InsuranceType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.insuranceTypeService.RetrieveById(id, InsuranceType.Informer, this.UserCredit);

        return result.ToActionResult<InsuranceType>();
    }

    [HttpGet]
    [Route("InsuranceType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.insuranceTypeService.RetrieveAll(InsuranceType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<InsuranceType>();
    }
            

    
    [HttpPost]
    [Route("InsuranceType/Save")]
    public async Task<IActionResult> Save([FromBody] InsuranceType insuranceType)
    {
        var result = await this.insuranceTypeService.Save(insuranceType, this.UserCredit);

        return result.ToActionResult<InsuranceType>();
    }

    
    [HttpPost]
    [Route("InsuranceType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] InsuranceType insuranceType)
    {
        var result = await this.insuranceTypeService.SaveAttached(insuranceType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("InsuranceType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<InsuranceType> insuranceTypeList)
    {
        var result = await this.insuranceTypeService.SaveBulk(insuranceTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("InsuranceType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] InsuranceType insuranceType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.insuranceTypeService.Seek(insuranceType, this.UserCredit, pageNumber);

        return result.ToActionResult<InsuranceType>();
    }

    [HttpGet]
    [Route("InsuranceType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.insuranceTypeService.SeekByValue(seekValue, InsuranceType.Informer);

        return result.ToActionResult<InsuranceType>();
    }

    [HttpDelete]
    [Route("InsuranceType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] InsuranceType insuranceType)
    {
        var result = await this.insuranceTypeService.Delete(insuranceType, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
