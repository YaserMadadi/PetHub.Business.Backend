
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
public class WorkTimeController : BaseController
{
    public WorkTimeController(IWorkTime_Service workTimeService)
    {
        this.workTimeService = workTimeService;
    }

    private IWorkTime_Service workTimeService { get; set; }

    [HttpGet]
    [Route("WorkTime/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.workTimeService.RetrieveById(id, WorkTime.Informer, this.UserCredit);

        return result.ToActionResult<WorkTime>();
    }

    [HttpGet]
    [Route("WorkTime/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.workTimeService.RetrieveAll(WorkTime.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<WorkTime>();
    }
            

    
    [HttpPost]
    [Route("WorkTime/Save")]
    public async Task<IActionResult> Save([FromBody] WorkTime workTime)
    {
        var result = await this.workTimeService.Save(workTime, this.UserCredit);

        return result.ToActionResult<WorkTime>();
    }

    
    [HttpPost]
    [Route("WorkTime/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] WorkTime workTime)
    {
        var result = await this.workTimeService.SaveAttached(workTime, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("WorkTime/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<WorkTime> workTimeList)
    {
        var result = await this.workTimeService.SaveBulk(workTimeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("WorkTime/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] WorkTime workTime, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.workTimeService.Seek(workTime, this.UserCredit, pageNumber);

        return result.ToActionResult<WorkTime>();
    }

    [HttpGet]
    [Route("WorkTime/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.workTimeService.SeekByValue(seekValue, WorkTime.Informer);

        return result.ToActionResult<WorkTime>();
    }

    [HttpDelete]
    [Route("WorkTime/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] WorkTime workTime)
    {
        var result = await this.workTimeService.Delete(workTime, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
