
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
public class ServiceOrientedWorkTimeController : BaseController
{
    public ServiceOrientedWorkTimeController(IServiceOrientedWorkTime_Service serviceOrientedWorkTimeService)
    {
        this.serviceOrientedWorkTimeService = serviceOrientedWorkTimeService;
    }

    private IServiceOrientedWorkTime_Service serviceOrientedWorkTimeService { get; set; }

    [HttpGet]
    [Route("ServiceOrientedWorkTime/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.serviceOrientedWorkTimeService.RetrieveById(id, ServiceOrientedWorkTime.Informer, this.UserCredit);

        return result.ToActionResult<ServiceOrientedWorkTime>();
    }

    [HttpGet]
    [Route("ServiceOrientedWorkTime/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.serviceOrientedWorkTimeService.RetrieveAll(ServiceOrientedWorkTime.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ServiceOrientedWorkTime>();
    }
            

    
    [HttpPost]
    [Route("ServiceOrientedWorkTime/Save")]
    public async Task<IActionResult> Save([FromBody] ServiceOrientedWorkTime serviceOrientedWorkTime)
    {
        var result = await this.serviceOrientedWorkTimeService.Save(serviceOrientedWorkTime, this.UserCredit);

        return result.ToActionResult<ServiceOrientedWorkTime>();
    }

    
    [HttpPost]
    [Route("ServiceOrientedWorkTime/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ServiceOrientedWorkTime serviceOrientedWorkTime)
    {
        var result = await this.serviceOrientedWorkTimeService.SaveAttached(serviceOrientedWorkTime, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ServiceOrientedWorkTime/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ServiceOrientedWorkTime> serviceOrientedWorkTimeList)
    {
        var result = await this.serviceOrientedWorkTimeService.SaveBulk(serviceOrientedWorkTimeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ServiceOrientedWorkTime/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ServiceOrientedWorkTime serviceOrientedWorkTime, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.serviceOrientedWorkTimeService.Seek(serviceOrientedWorkTime, this.UserCredit, pageNumber);

        return result.ToActionResult<ServiceOrientedWorkTime>();
    }

    [HttpGet]
    [Route("ServiceOrientedWorkTime/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.serviceOrientedWorkTimeService.SeekByValue(seekValue, ServiceOrientedWorkTime.Informer);

        return result.ToActionResult<ServiceOrientedWorkTime>();
    }

    [HttpDelete]
    [Route("ServiceOrientedWorkTime/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ServiceOrientedWorkTime serviceOrientedWorkTime)
    {
        var result = await this.serviceOrientedWorkTimeService.Delete(serviceOrientedWorkTime, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
