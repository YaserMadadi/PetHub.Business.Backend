
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
public class BackgroundCheckStatusController : BaseController
{
    public BackgroundCheckStatusController(IBackgroundCheckStatus_Service backgroundCheckStatusService)
    {
        this.backgroundCheckStatusService = backgroundCheckStatusService;
    }

    private IBackgroundCheckStatus_Service backgroundCheckStatusService { get; set; }

    [HttpGet]
    [Route("BackgroundCheckStatus/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.backgroundCheckStatusService.RetrieveById(id, BackgroundCheckStatus.Informer, this.UserCredit);

        return result.ToActionResult<BackgroundCheckStatus>();
    }

    [HttpGet]
    [Route("BackgroundCheckStatus/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.backgroundCheckStatusService.RetrieveAll(BackgroundCheckStatus.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<BackgroundCheckStatus>();
    }
            

    
    [HttpPost]
    [Route("BackgroundCheckStatus/Save")]
    public async Task<IActionResult> Save([FromBody] BackgroundCheckStatus backgroundCheckStatus)
    {
        var result = await this.backgroundCheckStatusService.Save(backgroundCheckStatus, this.UserCredit);

        return result.ToActionResult<BackgroundCheckStatus>();
    }

    
    [HttpPost]
    [Route("BackgroundCheckStatus/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] BackgroundCheckStatus backgroundCheckStatus)
    {
        var result = await this.backgroundCheckStatusService.SaveAttached(backgroundCheckStatus, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("BackgroundCheckStatus/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<BackgroundCheckStatus> backgroundCheckStatusList)
    {
        var result = await this.backgroundCheckStatusService.SaveBulk(backgroundCheckStatusList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("BackgroundCheckStatus/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] BackgroundCheckStatus backgroundCheckStatus, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.backgroundCheckStatusService.Seek(backgroundCheckStatus, this.UserCredit, pageNumber);

        return result.ToActionResult<BackgroundCheckStatus>();
    }

    [HttpGet]
    [Route("BackgroundCheckStatus/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.backgroundCheckStatusService.SeekByValue(seekValue, BackgroundCheckStatus.Informer);

        return result.ToActionResult<BackgroundCheckStatus>();
    }

    [HttpDelete]
    [Route("BackgroundCheckStatus/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BackgroundCheckStatus backgroundCheckStatus)
    {
        var result = await this.backgroundCheckStatusService.Delete(backgroundCheckStatus, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
