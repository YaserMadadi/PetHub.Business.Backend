
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
public class CityController : BaseController
{
    public CityController(ICity_Service cityService)
    {
        this.cityService = cityService;
    }

    private ICity_Service cityService { get; set; }

    [HttpGet]
    [Route("City/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.cityService.RetrieveById(id, City.Informer, this.UserCredit);

        return result.ToActionResult<City>();
    }

    [HttpGet]
    [Route("City/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.cityService.RetrieveAll(City.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<City>();
    }
            

    
    [HttpPost]
    [Route("City/Save")]
    public async Task<IActionResult> Save([FromBody] City city)
    {
        var result = await this.cityService.Save(city, this.UserCredit);

        return result.ToActionResult<City>();
    }

    
    [HttpPost]
    [Route("City/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] City city)
    {
        var result = await this.cityService.SaveAttached(city, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("City/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<City> cityList)
    {
        var result = await this.cityService.SaveBulk(cityList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("City/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] City city, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.cityService.Seek(city, this.UserCredit, pageNumber);

        return result.ToActionResult<City>();
    }

    [HttpGet]
    [Route("City/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.cityService.SeekByValue(seekValue, City.Informer);

        return result.ToActionResult<City>();
    }

    [HttpDelete]
    [Route("City/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] City city)
    {
        var result = await this.cityService.Delete(city, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// City.CollectionOfClient
    [HttpPost]
    [Route("City/{city_id:int}/Client")]
    public IActionResult CollectionOfClient([FromRoute(Name = "city_id")] int id, [FromBody] Client client)
    {
        return this.cityService.CollectionOfClient(id, client, this.UserCredit).ToActionResult();
    }

		//// City.CollectionOfLocationCoverage
    [HttpPost]
    [Route("City/{city_id:int}/LocationCoverage")]
    public IActionResult CollectionOfLocationCoverage([FromRoute(Name = "city_id")] int id, [FromBody] LocationCoverage locationCoverage)
    {
        return this.cityService.CollectionOfLocationCoverage(id, locationCoverage, this.UserCredit).ToActionResult();
    }
}
