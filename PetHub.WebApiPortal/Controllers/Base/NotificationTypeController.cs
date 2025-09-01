
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
public class NotificationTypeController : BaseController
{
    public NotificationTypeController(INotificationType_Service notificationTypeService)
    {
        this.notificationTypeService = notificationTypeService;
    }

    private INotificationType_Service notificationTypeService { get; set; }

    [HttpGet]
    [Route("NotificationType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.notificationTypeService.RetrieveById(id, NotificationType.Informer, this.UserCredit);

        return result.ToActionResult<NotificationType>();
    }

    [HttpGet]
    [Route("NotificationType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.notificationTypeService.RetrieveAll(NotificationType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<NotificationType>();
    }
            

    
    [HttpPost]
    [Route("NotificationType/Save")]
    public async Task<IActionResult> Save([FromBody] NotificationType notificationType)
    {
        var result = await this.notificationTypeService.Save(notificationType, this.UserCredit);

        return result.ToActionResult<NotificationType>();
    }

    
    [HttpPost]
    [Route("NotificationType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] NotificationType notificationType)
    {
        var result = await this.notificationTypeService.SaveAttached(notificationType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("NotificationType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<NotificationType> notificationTypeList)
    {
        var result = await this.notificationTypeService.SaveBulk(notificationTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("NotificationType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] NotificationType notificationType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.notificationTypeService.Seek(notificationType, this.UserCredit, pageNumber);

        return result.ToActionResult<NotificationType>();
    }

    [HttpGet]
    [Route("NotificationType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.notificationTypeService.SeekByValue(seekValue, NotificationType.Informer);

        return result.ToActionResult<NotificationType>();
    }

    [HttpDelete]
    [Route("NotificationType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] NotificationType notificationType)
    {
        var result = await this.notificationTypeService.Delete(notificationType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// NotificationType.CollectionOfClientNotification
    [HttpPost]
    [Route("NotificationType/{notificationType_id:int}/ClientNotification")]
    public IActionResult CollectionOfClientNotification([FromRoute(Name = "notificationType_id")] int id, [FromBody] ClientNotification clientNotification)
    {
        return this.notificationTypeService.CollectionOfClientNotification(id, clientNotification, this.UserCredit).ToActionResult();
    }
}
