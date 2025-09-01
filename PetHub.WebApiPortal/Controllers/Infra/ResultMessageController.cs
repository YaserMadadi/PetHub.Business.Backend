
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
public class ResultMessageController : BaseController
{
    public ResultMessageController(IResultMessage_Service resultMessageService)
    {
        this.resultMessageService = resultMessageService;
    }

    private IResultMessage_Service resultMessageService { get; set; }

    [HttpGet]
    [Route("ResultMessage/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.resultMessageService.RetrieveById(id, ResultMessage.Informer, this.UserCredit);

        return result.ToActionResult<ResultMessage>();
    }

    [HttpGet]
    [Route("ResultMessage/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.resultMessageService.RetrieveAll(ResultMessage.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ResultMessage>();
    }
            

    
    [HttpPost]
    [Route("ResultMessage/Save")]
    public async Task<IActionResult> Save([FromBody] ResultMessage resultMessage)
    {
        var result = await this.resultMessageService.Save(resultMessage, this.UserCredit);

        return result.ToActionResult<ResultMessage>();
    }

    
    [HttpPost]
    [Route("ResultMessage/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ResultMessage resultMessage)
    {
        var result = await this.resultMessageService.SaveAttached(resultMessage, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ResultMessage/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ResultMessage> resultMessageList)
    {
        var result = await this.resultMessageService.SaveBulk(resultMessageList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ResultMessage/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ResultMessage resultMessage, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.resultMessageService.Seek(resultMessage, this.UserCredit, pageNumber);

        return result.ToActionResult<ResultMessage>();
    }

    [HttpGet]
    [Route("ResultMessage/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.resultMessageService.SeekByValue(seekValue, ResultMessage.Informer);

        return result.ToActionResult<ResultMessage>();
    }

    [HttpDelete]
    [Route("ResultMessage/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ResultMessage resultMessage)
    {
        var result = await this.resultMessageService.Delete(resultMessage, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
