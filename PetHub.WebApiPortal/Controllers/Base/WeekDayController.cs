
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
public class WeekDayController : BaseController
{
    public WeekDayController(IWeekDay_Service weekDayService)
    {
        this.weekDayService = weekDayService;
    }

    private IWeekDay_Service weekDayService { get; set; }

    [HttpGet]
    [Route("WeekDay/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.weekDayService.RetrieveById(id, WeekDay.Informer, this.UserCredit);

        return result.ToActionResult<WeekDay>();
    }

    [HttpGet]
    [Route("WeekDay/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.weekDayService.RetrieveAll(WeekDay.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<WeekDay>();
    }
            

    
    [HttpPost]
    [Route("WeekDay/Save")]
    public async Task<IActionResult> Save([FromBody] WeekDay weekDay)
    {
        var result = await this.weekDayService.Save(weekDay, this.UserCredit);

        return result.ToActionResult<WeekDay>();
    }

    
    [HttpPost]
    [Route("WeekDay/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] WeekDay weekDay)
    {
        var result = await this.weekDayService.SaveAttached(weekDay, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("WeekDay/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<WeekDay> weekDayList)
    {
        var result = await this.weekDayService.SaveBulk(weekDayList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("WeekDay/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] WeekDay weekDay, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.weekDayService.Seek(weekDay, this.UserCredit, pageNumber);

        return result.ToActionResult<WeekDay>();
    }

    [HttpGet]
    [Route("WeekDay/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.weekDayService.SeekByValue(seekValue, WeekDay.Informer);

        return result.ToActionResult<WeekDay>();
    }

    [HttpDelete]
    [Route("WeekDay/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] WeekDay weekDay)
    {
        var result = await this.weekDayService.Delete(weekDay, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// WeekDay.CollectionOfServiceOrientedWorkTime
    [HttpPost]
    [Route("WeekDay/{weekDay_id:int}/ServiceOrientedWorkTime")]
    public IActionResult CollectionOfServiceOrientedWorkTime([FromRoute(Name = "weekDay_id")] int id, [FromBody] ServiceOrientedWorkTime serviceOrientedWorkTime)
    {
        return this.weekDayService.CollectionOfServiceOrientedWorkTime(id, serviceOrientedWorkTime, this.UserCredit).ToActionResult();
    }

		//// WeekDay.CollectionOfWorkTime
    [HttpPost]
    [Route("WeekDay/{weekDay_id:int}/WorkTime")]
    public IActionResult CollectionOfWorkTime([FromRoute(Name = "weekDay_id")] int id, [FromBody] WorkTime workTime)
    {
        return this.weekDayService.CollectionOfWorkTime(id, workTime, this.UserCredit).ToActionResult();
    }
}
