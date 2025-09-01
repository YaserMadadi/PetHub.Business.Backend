
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
public class DurationUnitController : BaseController
{
    public DurationUnitController(IDurationUnit_Service durationUnitService)
    {
        this.durationUnitService = durationUnitService;
    }

    private IDurationUnit_Service durationUnitService { get; set; }

    [HttpGet]
    [Route("DurationUnit/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.durationUnitService.RetrieveById(id, DurationUnit.Informer, this.UserCredit);

        return result.ToActionResult<DurationUnit>();
    }

    [HttpGet]
    [Route("DurationUnit/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.durationUnitService.RetrieveAll(DurationUnit.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<DurationUnit>();
    }
            

    
    [HttpPost]
    [Route("DurationUnit/Save")]
    public async Task<IActionResult> Save([FromBody] DurationUnit durationUnit)
    {
        var result = await this.durationUnitService.Save(durationUnit, this.UserCredit);

        return result.ToActionResult<DurationUnit>();
    }

    
    [HttpPost]
    [Route("DurationUnit/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] DurationUnit durationUnit)
    {
        var result = await this.durationUnitService.SaveAttached(durationUnit, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("DurationUnit/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<DurationUnit> durationUnitList)
    {
        var result = await this.durationUnitService.SaveBulk(durationUnitList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("DurationUnit/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] DurationUnit durationUnit, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.durationUnitService.Seek(durationUnit, this.UserCredit, pageNumber);

        return result.ToActionResult<DurationUnit>();
    }

    [HttpGet]
    [Route("DurationUnit/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.durationUnitService.SeekByValue(seekValue, DurationUnit.Informer);

        return result.ToActionResult<DurationUnit>();
    }

    [HttpDelete]
    [Route("DurationUnit/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] DurationUnit durationUnit)
    {
        var result = await this.durationUnitService.Delete(durationUnit, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// DurationUnit.CollectionOfBooking
    [HttpPost]
    [Route("DurationUnit/{durationUnit_id:int}/Booking")]
    public IActionResult CollectionOfBooking([FromRoute(Name = "durationUnit_id")] int id, [FromBody] Booking booking)
    {
        return this.durationUnitService.CollectionOfBooking(id, booking, this.UserCredit).ToActionResult();
    }
}
