
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Fund.Abstract;
using PetHub.Entities.Fund;

namespace PetHub.ApiServices.Controllers.Fund;

[Route("api/Fund")]
public class ProviderPayOutController : BaseController
{
    public ProviderPayOutController(IProviderPayOut_Service providerPayOutService)
    {
        this.providerPayOutService = providerPayOutService;
    }

    private IProviderPayOut_Service providerPayOutService { get; set; }

    [HttpGet]
    [Route("ProviderPayOut/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerPayOutService.RetrieveById(id, ProviderPayOut.Informer, this.UserCredit);

        return result.ToActionResult<ProviderPayOut>();
    }

    [HttpGet]
    [Route("ProviderPayOut/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerPayOutService.RetrieveAll(ProviderPayOut.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ProviderPayOut>();
    }
            

    
    [HttpPost]
    [Route("ProviderPayOut/Save")]
    public async Task<IActionResult> Save([FromBody] ProviderPayOut providerPayOut)
    {
        var result = await this.providerPayOutService.Save(providerPayOut, this.UserCredit);

        return result.ToActionResult<ProviderPayOut>();
    }

    
    [HttpPost]
    [Route("ProviderPayOut/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ProviderPayOut providerPayOut)
    {
        var result = await this.providerPayOutService.SaveAttached(providerPayOut, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ProviderPayOut/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ProviderPayOut> providerPayOutList)
    {
        var result = await this.providerPayOutService.SaveBulk(providerPayOutList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ProviderPayOut/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ProviderPayOut providerPayOut, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerPayOutService.Seek(providerPayOut, this.UserCredit, pageNumber);

        return result.ToActionResult<ProviderPayOut>();
    }

    [HttpGet]
    [Route("ProviderPayOut/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerPayOutService.SeekByValue(seekValue, ProviderPayOut.Informer);

        return result.ToActionResult<ProviderPayOut>();
    }

    [HttpDelete]
    [Route("ProviderPayOut/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ProviderPayOut providerPayOut)
    {
        var result = await this.providerPayOutService.Delete(providerPayOut, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
