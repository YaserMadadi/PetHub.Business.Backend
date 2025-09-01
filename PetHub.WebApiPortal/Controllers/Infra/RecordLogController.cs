
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
public class RecordLogController : BaseController
{
    public RecordLogController(IRecordLog_Service recordLogService)
    {
        this.recordLogService = recordLogService;
    }

    private IRecordLog_Service recordLogService { get; set; }

    [HttpGet]
    [Route("RecordLog/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.recordLogService.RetrieveById(id, RecordLog.Informer, this.UserCredit);

        return result.ToActionResult<RecordLog>();
    }

    [HttpGet]
    [Route("RecordLog/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.recordLogService.RetrieveAll(RecordLog.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<RecordLog>();
    }
            

    
    [HttpPost]
    [Route("RecordLog/Save")]
    public async Task<IActionResult> Save([FromBody] RecordLog recordLog)
    {
        var result = await this.recordLogService.Save(recordLog, this.UserCredit);

        return result.ToActionResult<RecordLog>();
    }

    
    [HttpPost]
    [Route("RecordLog/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] RecordLog recordLog)
    {
        var result = await this.recordLogService.SaveAttached(recordLog, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("RecordLog/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<RecordLog> recordLogList)
    {
        var result = await this.recordLogService.SaveBulk(recordLogList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("RecordLog/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] RecordLog recordLog, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.recordLogService.Seek(recordLog, this.UserCredit, pageNumber);

        return result.ToActionResult<RecordLog>();
    }

    [HttpGet]
    [Route("RecordLog/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.recordLogService.SeekByValue(seekValue, RecordLog.Informer);

        return result.ToActionResult<RecordLog>();
    }

    [HttpDelete]
    [Route("RecordLog/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] RecordLog recordLog)
    {
        var result = await this.recordLogService.Delete(recordLog, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
