
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
public class ServicePriceController : BaseController
{
    public ServicePriceController(IServicePrice_Service servicePriceService)
    {
        this.servicePriceService = servicePriceService;
    }

    private IServicePrice_Service servicePriceService { get; set; }

    [HttpGet]
    [Route("ServicePrice/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.servicePriceService.RetrieveById(id, ServicePrice.Informer, this.UserCredit);

        return result.ToActionResult<ServicePrice>();
    }

    [HttpGet]
    [Route("ServicePrice/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.servicePriceService.RetrieveAll(ServicePrice.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ServicePrice>();
    }
            

    
    [HttpPost]
    [Route("ServicePrice/Save")]
    public async Task<IActionResult> Save([FromBody] ServicePrice servicePrice)
    {
        var result = await this.servicePriceService.Save(servicePrice, this.UserCredit);

        return result.ToActionResult<ServicePrice>();
    }

    
    [HttpPost]
    [Route("ServicePrice/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ServicePrice servicePrice)
    {
        var result = await this.servicePriceService.SaveAttached(servicePrice, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ServicePrice/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ServicePrice> servicePriceList)
    {
        var result = await this.servicePriceService.SaveBulk(servicePriceList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ServicePrice/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ServicePrice servicePrice, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.servicePriceService.Seek(servicePrice, this.UserCredit, pageNumber);

        return result.ToActionResult<ServicePrice>();
    }

    [HttpGet]
    [Route("ServicePrice/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.servicePriceService.SeekByValue(seekValue, ServicePrice.Informer);

        return result.ToActionResult<ServicePrice>();
    }

    [HttpDelete]
    [Route("ServicePrice/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ServicePrice servicePrice)
    {
        var result = await this.servicePriceService.Delete(servicePrice, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
