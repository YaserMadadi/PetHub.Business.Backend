
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Infra.Abstract;
using PetHub.Entities.Infra;

namespace PetHub.ApiServices.Controllers.Infra;

[Route("api/Infra")]
public class MessageTypeController : BaseController
{
    public MessageTypeController(IMessageType_Service messageTypeService)
    {
        this.messageTypeService = messageTypeService;
    }

    private IMessageType_Service messageTypeService { get; set; }

    [HttpGet]
    [Route("MessageType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.messageTypeService.RetrieveById(id, MessageType.Informer, this.UserCredit);

        return result.ToActionResult<MessageType>();
    }

    [HttpGet]
    [Route("MessageType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.messageTypeService.RetrieveAll(MessageType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<MessageType>();
    }
            

    
    [HttpPost]
    [Route("MessageType/Save")]
    public async Task<IActionResult> Save([FromBody] MessageType messageType)
    {
        var result = await this.messageTypeService.Save(messageType, this.UserCredit);

        return result.ToActionResult<MessageType>();
    }

    
    [HttpPost]
    [Route("MessageType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] MessageType messageType)
    {
        var result = await this.messageTypeService.SaveAttached(messageType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("MessageType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<MessageType> messageTypeList)
    {
        var result = await this.messageTypeService.SaveBulk(messageTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("MessageType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] MessageType messageType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.messageTypeService.Seek(messageType, this.UserCredit, pageNumber);

        return result.ToActionResult<MessageType>();
    }

    [HttpGet]
    [Route("MessageType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.messageTypeService.SeekByValue(seekValue, MessageType.Informer);

        return result.ToActionResult<MessageType>();
    }

    [HttpDelete]
    [Route("MessageType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MessageType messageType)
    {
        var result = await this.messageTypeService.Delete(messageType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// MessageType.CollectionOfResultMessage
    [HttpPost]
    [Route("MessageType/{messageType_id:int}/ResultMessage")]
    public IActionResult CollectionOfResultMessage([FromRoute(Name = "messageType_id")] int id, [FromBody] ResultMessage resultMessage)
    {
        return this.messageTypeService.CollectionOfResultMessage(id, resultMessage, this.UserCredit).ToActionResult();
    }
}
