
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
public class CountryController : BaseController
{
    public CountryController(ICountry_Service countryService)
    {
        this.countryService = countryService;
    }

    private ICountry_Service countryService { get; set; }

    [HttpGet]
    [Route("Country/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.countryService.RetrieveById(id, Country.Informer, this.UserCredit);

        return result.ToActionResult<Country>();
    }

    [HttpGet]
    [Route("Country/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.countryService.RetrieveAll(Country.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Country>();
    }
            

    
    [HttpPost]
    [Route("Country/Save")]
    public async Task<IActionResult> Save([FromBody] Country country)
    {
        var result = await this.countryService.Save(country, this.UserCredit);

        return result.ToActionResult<Country>();
    }

    
    [HttpPost]
    [Route("Country/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Country country)
    {
        var result = await this.countryService.SaveAttached(country, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Country/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Country> countryList)
    {
        var result = await this.countryService.SaveBulk(countryList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Country/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Country country, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.countryService.Seek(country, this.UserCredit, pageNumber);

        return result.ToActionResult<Country>();
    }

    [HttpGet]
    [Route("Country/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.countryService.SeekByValue(seekValue, Country.Informer);

        return result.ToActionResult<Country>();
    }

    [HttpDelete]
    [Route("Country/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Country country)
    {
        var result = await this.countryService.Delete(country, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Country.CollectionOfProvince
    [HttpPost]
    [Route("Country/{country_id:int}/Province")]
    public IActionResult CollectionOfProvince([FromRoute(Name = "country_id")] int id, [FromBody] Province province)
    {
        return this.countryService.CollectionOfProvince(id, province, this.UserCredit).ToActionResult();
    }
}
