
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
public class ProviderConnectionController : BaseController
{
    public ProviderConnectionController(IProviderConnection_Service providerConnectionService)
    {
        this.providerConnectionService = providerConnectionService;
    }

    private IProviderConnection_Service providerConnectionService { get; set; }

    [HttpGet]
    [Route("ProviderConnection/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerConnectionService.RetrieveById(id, ProviderConnection.Informer, this.UserCredit);

        return result.ToActionResult<ProviderConnection>();
    }

    [HttpGet]
    [Route("ProviderConnection/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerConnectionService.RetrieveAll(ProviderConnection.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ProviderConnection>();
    }
            

    
    [HttpPost]
    [Route("ProviderConnection/Save")]
    public async Task<IActionResult> Save([FromBody] ProviderConnection providerConnection)
    {
        var result = await this.providerConnectionService.Save(providerConnection, this.UserCredit);

        return result.ToActionResult<ProviderConnection>();
    }

    
    [HttpPost]
    [Route("ProviderConnection/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ProviderConnection providerConnection)
    {
        var result = await this.providerConnectionService.SaveAttached(providerConnection, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ProviderConnection/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ProviderConnection> providerConnectionList)
    {
        var result = await this.providerConnectionService.SaveBulk(providerConnectionList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ProviderConnection/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ProviderConnection providerConnection, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerConnectionService.Seek(providerConnection, this.UserCredit, pageNumber);

        return result.ToActionResult<ProviderConnection>();
    }

    [HttpGet]
    [Route("ProviderConnection/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerConnectionService.SeekByValue(seekValue, ProviderConnection.Informer);

        return result.ToActionResult<ProviderConnection>();
    }

    [HttpDelete]
    [Route("ProviderConnection/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ProviderConnection providerConnection)
    {
        var result = await this.providerConnectionService.Delete(providerConnection, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
