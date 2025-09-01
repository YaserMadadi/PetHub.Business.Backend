
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
public class LocationCoverageController : BaseController
{
    public LocationCoverageController(ILocationCoverage_Service locationCoverageService)
    {
        this.locationCoverageService = locationCoverageService;
    }

    private ILocationCoverage_Service locationCoverageService { get; set; }

    [HttpGet]
    [Route("LocationCoverage/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.locationCoverageService.RetrieveById(id, LocationCoverage.Informer, this.UserCredit);

        return result.ToActionResult<LocationCoverage>();
    }

    [HttpGet]
    [Route("LocationCoverage/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.locationCoverageService.RetrieveAll(LocationCoverage.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<LocationCoverage>();
    }
            

    
    [HttpPost]
    [Route("LocationCoverage/Save")]
    public async Task<IActionResult> Save([FromBody] LocationCoverage locationCoverage)
    {
        var result = await this.locationCoverageService.Save(locationCoverage, this.UserCredit);

        return result.ToActionResult<LocationCoverage>();
    }

    
    [HttpPost]
    [Route("LocationCoverage/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] LocationCoverage locationCoverage)
    {
        var result = await this.locationCoverageService.SaveAttached(locationCoverage, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("LocationCoverage/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<LocationCoverage> locationCoverageList)
    {
        var result = await this.locationCoverageService.SaveBulk(locationCoverageList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("LocationCoverage/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] LocationCoverage locationCoverage, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.locationCoverageService.Seek(locationCoverage, this.UserCredit, pageNumber);

        return result.ToActionResult<LocationCoverage>();
    }

    [HttpGet]
    [Route("LocationCoverage/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.locationCoverageService.SeekByValue(seekValue, LocationCoverage.Informer);

        return result.ToActionResult<LocationCoverage>();
    }

    [HttpDelete]
    [Route("LocationCoverage/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] LocationCoverage locationCoverage)
    {
        var result = await this.locationCoverageService.Delete(locationCoverage, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
