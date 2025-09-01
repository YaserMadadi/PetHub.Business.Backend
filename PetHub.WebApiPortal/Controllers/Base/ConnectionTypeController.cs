
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
public class ConnectionTypeController : BaseController
{
    public ConnectionTypeController(IConnectionType_Service connectionTypeService)
    {
        this.connectionTypeService = connectionTypeService;
    }

    private IConnectionType_Service connectionTypeService { get; set; }

    [HttpGet]
    [Route("ConnectionType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.connectionTypeService.RetrieveById(id, ConnectionType.Informer, this.UserCredit);

        return result.ToActionResult<ConnectionType>();
    }

    [HttpGet]
    [Route("ConnectionType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.connectionTypeService.RetrieveAll(ConnectionType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ConnectionType>();
    }
            

    
    [HttpPost]
    [Route("ConnectionType/Save")]
    public async Task<IActionResult> Save([FromBody] ConnectionType connectionType)
    {
        var result = await this.connectionTypeService.Save(connectionType, this.UserCredit);

        return result.ToActionResult<ConnectionType>();
    }

    
    [HttpPost]
    [Route("ConnectionType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ConnectionType connectionType)
    {
        var result = await this.connectionTypeService.SaveAttached(connectionType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ConnectionType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ConnectionType> connectionTypeList)
    {
        var result = await this.connectionTypeService.SaveBulk(connectionTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ConnectionType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ConnectionType connectionType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.connectionTypeService.Seek(connectionType, this.UserCredit, pageNumber);

        return result.ToActionResult<ConnectionType>();
    }

    [HttpGet]
    [Route("ConnectionType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.connectionTypeService.SeekByValue(seekValue, ConnectionType.Informer);

        return result.ToActionResult<ConnectionType>();
    }

    [HttpDelete]
    [Route("ConnectionType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConnectionType connectionType)
    {
        var result = await this.connectionTypeService.Delete(connectionType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// ConnectionType.CollectionOfProviderConnection
    [HttpPost]
    [Route("ConnectionType/{connectionType_id:int}/ProviderConnection")]
    public IActionResult CollectionOfProviderConnection([FromRoute(Name = "connectionType_id")] int id, [FromBody] ProviderConnection providerConnection)
    {
        return this.connectionTypeService.CollectionOfProviderConnection(id, providerConnection, this.UserCredit).ToActionResult();
    }
}
