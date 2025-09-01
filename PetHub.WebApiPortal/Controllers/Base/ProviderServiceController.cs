
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
public class ProviderServiceController : BaseController
{
    public ProviderServiceController(IProviderService_Service providerServiceService)
    {
        this.providerServiceService = providerServiceService;
    }

    private IProviderService_Service providerServiceService { get; set; }

    [HttpGet]
    [Route("ProviderService/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerServiceService.RetrieveById(id, ProviderService.Informer, this.UserCredit);

        return result.ToActionResult<ProviderService>();
    }

    [HttpGet]
    [Route("ProviderService/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerServiceService.RetrieveAll(ProviderService.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ProviderService>();
    }
            

    
    [HttpPost]
    [Route("ProviderService/Save")]
    public async Task<IActionResult> Save([FromBody] ProviderService providerService)
    {
        var result = await this.providerServiceService.Save(providerService, this.UserCredit);

        return result.ToActionResult<ProviderService>();
    }

    
    [HttpPost]
    [Route("ProviderService/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ProviderService providerService)
    {
        var result = await this.providerServiceService.SaveAttached(providerService, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ProviderService/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ProviderService> providerServiceList)
    {
        var result = await this.providerServiceService.SaveBulk(providerServiceList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ProviderService/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ProviderService providerService, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerServiceService.Seek(providerService, this.UserCredit, pageNumber);

        return result.ToActionResult<ProviderService>();
    }

    [HttpGet]
    [Route("ProviderService/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerServiceService.SeekByValue(seekValue, ProviderService.Informer);

        return result.ToActionResult<ProviderService>();
    }

    [HttpDelete]
    [Route("ProviderService/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ProviderService providerService)
    {
        var result = await this.providerServiceService.Delete(providerService, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// ProviderService.CollectionOfBookingService
    [HttpPost]
    [Route("ProviderService/{providerService_id:int}/BookingService")]
    public IActionResult CollectionOfBookingService([FromRoute(Name = "providerService_id")] int id, [FromBody] BookingService bookingService)
    {
        return this.providerServiceService.CollectionOfBookingService(id, bookingService, this.UserCredit).ToActionResult();
    }

		//// ProviderService.CollectionOfServiceOrientedWorkTime
    [HttpPost]
    [Route("ProviderService/{providerService_id:int}/ServiceOrientedWorkTime")]
    public IActionResult CollectionOfServiceOrientedWorkTime([FromRoute(Name = "providerService_id")] int id, [FromBody] ServiceOrientedWorkTime serviceOrientedWorkTime)
    {
        return this.providerServiceService.CollectionOfServiceOrientedWorkTime(id, serviceOrientedWorkTime, this.UserCredit).ToActionResult();
    }

		//// ProviderService.CollectionOfServicePrice
    [HttpPost]
    [Route("ProviderService/{providerService_id:int}/ServicePrice")]
    public IActionResult CollectionOfServicePrice([FromRoute(Name = "providerService_id")] int id, [FromBody] ServicePrice servicePrice)
    {
        return this.providerServiceService.CollectionOfServicePrice(id, servicePrice, this.UserCredit).ToActionResult();
    }
}
