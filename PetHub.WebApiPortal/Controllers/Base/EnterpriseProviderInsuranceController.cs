
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
public class EnterpriseProviderInsuranceController : BaseController
{
    public EnterpriseProviderInsuranceController(IEnterpriseProviderInsurance_Service enterpriseProviderInsuranceService)
    {
        this.enterpriseProviderInsuranceService = enterpriseProviderInsuranceService;
    }

    private IEnterpriseProviderInsurance_Service enterpriseProviderInsuranceService { get; set; }

    [HttpGet]
    [Route("EnterpriseProviderInsurance/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.enterpriseProviderInsuranceService.RetrieveById(id, EnterpriseProviderInsurance.Informer, this.UserCredit);

        return result.ToActionResult<EnterpriseProviderInsurance>();
    }

    [HttpGet]
    [Route("EnterpriseProviderInsurance/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.enterpriseProviderInsuranceService.RetrieveAll(EnterpriseProviderInsurance.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<EnterpriseProviderInsurance>();
    }
            

    
    [HttpPost]
    [Route("EnterpriseProviderInsurance/Save")]
    public async Task<IActionResult> Save([FromBody] EnterpriseProviderInsurance enterpriseProviderInsurance)
    {
        var result = await this.enterpriseProviderInsuranceService.Save(enterpriseProviderInsurance, this.UserCredit);

        return result.ToActionResult<EnterpriseProviderInsurance>();
    }

    
    [HttpPost]
    [Route("EnterpriseProviderInsurance/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] EnterpriseProviderInsurance enterpriseProviderInsurance)
    {
        var result = await this.enterpriseProviderInsuranceService.SaveAttached(enterpriseProviderInsurance, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("EnterpriseProviderInsurance/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<EnterpriseProviderInsurance> enterpriseProviderInsuranceList)
    {
        var result = await this.enterpriseProviderInsuranceService.SaveBulk(enterpriseProviderInsuranceList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("EnterpriseProviderInsurance/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] EnterpriseProviderInsurance enterpriseProviderInsurance, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.enterpriseProviderInsuranceService.Seek(enterpriseProviderInsurance, this.UserCredit, pageNumber);

        return result.ToActionResult<EnterpriseProviderInsurance>();
    }

    [HttpGet]
    [Route("EnterpriseProviderInsurance/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.enterpriseProviderInsuranceService.SeekByValue(seekValue, EnterpriseProviderInsurance.Informer);

        return result.ToActionResult<EnterpriseProviderInsurance>();
    }

    [HttpDelete]
    [Route("EnterpriseProviderInsurance/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EnterpriseProviderInsurance enterpriseProviderInsurance)
    {
        var result = await this.enterpriseProviderInsuranceService.Delete(enterpriseProviderInsurance, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
