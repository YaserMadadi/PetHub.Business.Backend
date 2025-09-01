
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
public class ClientNotificationController : BaseController
{
    public ClientNotificationController(IClientNotification_Service clientNotificationService)
    {
        this.clientNotificationService = clientNotificationService;
    }

    private IClientNotification_Service clientNotificationService { get; set; }

    [HttpGet]
    [Route("ClientNotification/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.clientNotificationService.RetrieveById(id, ClientNotification.Informer, this.UserCredit);

        return result.ToActionResult<ClientNotification>();
    }

    [HttpGet]
    [Route("ClientNotification/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.clientNotificationService.RetrieveAll(ClientNotification.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ClientNotification>();
    }
            

    
    [HttpPost]
    [Route("ClientNotification/Save")]
    public async Task<IActionResult> Save([FromBody] ClientNotification clientNotification)
    {
        var result = await this.clientNotificationService.Save(clientNotification, this.UserCredit);

        return result.ToActionResult<ClientNotification>();
    }

    
    [HttpPost]
    [Route("ClientNotification/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ClientNotification clientNotification)
    {
        var result = await this.clientNotificationService.SaveAttached(clientNotification, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ClientNotification/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ClientNotification> clientNotificationList)
    {
        var result = await this.clientNotificationService.SaveBulk(clientNotificationList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ClientNotification/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ClientNotification clientNotification, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.clientNotificationService.Seek(clientNotification, this.UserCredit, pageNumber);

        return result.ToActionResult<ClientNotification>();
    }

    [HttpGet]
    [Route("ClientNotification/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.clientNotificationService.SeekByValue(seekValue, ClientNotification.Informer);

        return result.ToActionResult<ClientNotification>();
    }

    [HttpDelete]
    [Route("ClientNotification/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ClientNotification clientNotification)
    {
        var result = await this.clientNotificationService.Delete(clientNotification, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
