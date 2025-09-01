
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
public class ProviderTypeController : BaseController
{
    public ProviderTypeController(IProviderType_Service providerTypeService)
    {
        this.providerTypeService = providerTypeService;
    }

    private IProviderType_Service providerTypeService { get; set; }

    [HttpGet]
    [Route("ProviderType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerTypeService.RetrieveById(id, ProviderType.Informer, this.UserCredit);

        return result.ToActionResult<ProviderType>();
    }

    [HttpGet]
    [Route("ProviderType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerTypeService.RetrieveAll(ProviderType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ProviderType>();
    }
            

    
    [HttpPost]
    [Route("ProviderType/Save")]
    public async Task<IActionResult> Save([FromBody] ProviderType providerType)
    {
        var result = await this.providerTypeService.Save(providerType, this.UserCredit);

        return result.ToActionResult<ProviderType>();
    }

    
    [HttpPost]
    [Route("ProviderType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ProviderType providerType)
    {
        var result = await this.providerTypeService.SaveAttached(providerType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ProviderType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ProviderType> providerTypeList)
    {
        var result = await this.providerTypeService.SaveBulk(providerTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ProviderType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ProviderType providerType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerTypeService.Seek(providerType, this.UserCredit, pageNumber);

        return result.ToActionResult<ProviderType>();
    }

    [HttpGet]
    [Route("ProviderType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerTypeService.SeekByValue(seekValue, ProviderType.Informer);

        return result.ToActionResult<ProviderType>();
    }

    [HttpDelete]
    [Route("ProviderType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ProviderType providerType)
    {
        var result = await this.providerTypeService.Delete(providerType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// ProviderType.CollectionOfProvider
    [HttpPost]
    [Route("ProviderType/{providerType_id:int}/Provider")]
    public IActionResult CollectionOfProvider([FromRoute(Name = "providerType_id")] int id, [FromBody] Provider provider)
    {
        return this.providerTypeService.CollectionOfProvider(id, provider, this.UserCredit).ToActionResult();
    }
}
