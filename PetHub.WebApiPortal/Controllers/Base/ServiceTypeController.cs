
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
public class ServiceTypeController : BaseController
{
    public ServiceTypeController(IServiceType_Service serviceTypeService)
    {
        this.serviceTypeService = serviceTypeService;
    }

    private IServiceType_Service serviceTypeService { get; set; }

    [HttpGet]
    [Route("ServiceType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.serviceTypeService.RetrieveById(id, ServiceType.Informer, this.UserCredit);

        return result.ToActionResult<ServiceType>();
    }

    [HttpGet]
    [Route("ServiceType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.serviceTypeService.RetrieveAll(ServiceType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ServiceType>();
    }
            

    
    [HttpPost]
    [Route("ServiceType/Save")]
    public async Task<IActionResult> Save([FromBody] ServiceType serviceType)
    {
        var result = await this.serviceTypeService.Save(serviceType, this.UserCredit);

        return result.ToActionResult<ServiceType>();
    }

    
    [HttpPost]
    [Route("ServiceType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ServiceType serviceType)
    {
        var result = await this.serviceTypeService.SaveAttached(serviceType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ServiceType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ServiceType> serviceTypeList)
    {
        var result = await this.serviceTypeService.SaveBulk(serviceTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ServiceType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ServiceType serviceType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.serviceTypeService.Seek(serviceType, this.UserCredit, pageNumber);

        return result.ToActionResult<ServiceType>();
    }

    [HttpGet]
    [Route("ServiceType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.serviceTypeService.SeekByValue(seekValue, ServiceType.Informer);

        return result.ToActionResult<ServiceType>();
    }

    [HttpDelete]
    [Route("ServiceType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ServiceType serviceType)
    {
        var result = await this.serviceTypeService.Delete(serviceType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// ServiceType.CollectionOfProviderService
    [HttpPost]
    [Route("ServiceType/{serviceType_id:int}/ProviderService")]
    public IActionResult CollectionOfProviderService([FromRoute(Name = "serviceType_id")] int id, [FromBody] ProviderService providerService)
    {
        return this.serviceTypeService.CollectionOfProviderService(id, providerService, this.UserCredit).ToActionResult();
    }
}
