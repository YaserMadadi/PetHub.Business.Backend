
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
public class PriceScopeController : BaseController
{
    public PriceScopeController(IPriceScope_Service priceScopeService)
    {
        this.priceScopeService = priceScopeService;
    }

    private IPriceScope_Service priceScopeService { get; set; }

    [HttpGet]
    [Route("PriceScope/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.priceScopeService.RetrieveById(id, PriceScope.Informer, this.UserCredit);

        return result.ToActionResult<PriceScope>();
    }

    [HttpGet]
    [Route("PriceScope/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.priceScopeService.RetrieveAll(PriceScope.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<PriceScope>();
    }
            

    
    [HttpPost]
    [Route("PriceScope/Save")]
    public async Task<IActionResult> Save([FromBody] PriceScope priceScope)
    {
        var result = await this.priceScopeService.Save(priceScope, this.UserCredit);

        return result.ToActionResult<PriceScope>();
    }

    
    [HttpPost]
    [Route("PriceScope/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] PriceScope priceScope)
    {
        var result = await this.priceScopeService.SaveAttached(priceScope, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("PriceScope/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<PriceScope> priceScopeList)
    {
        var result = await this.priceScopeService.SaveBulk(priceScopeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("PriceScope/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] PriceScope priceScope, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.priceScopeService.Seek(priceScope, this.UserCredit, pageNumber);

        return result.ToActionResult<PriceScope>();
    }

    [HttpGet]
    [Route("PriceScope/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.priceScopeService.SeekByValue(seekValue, PriceScope.Informer);

        return result.ToActionResult<PriceScope>();
    }

    [HttpDelete]
    [Route("PriceScope/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PriceScope priceScope)
    {
        var result = await this.priceScopeService.Delete(priceScope, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// PriceScope.CollectionOfServicePrice
    [HttpPost]
    [Route("PriceScope/{priceScope_id:int}/ServicePrice")]
    public IActionResult CollectionOfServicePrice([FromRoute(Name = "priceScope_id")] int id, [FromBody] ServicePrice servicePrice)
    {
        return this.priceScopeService.CollectionOfServicePrice(id, servicePrice, this.UserCredit).ToActionResult();
    }
}
