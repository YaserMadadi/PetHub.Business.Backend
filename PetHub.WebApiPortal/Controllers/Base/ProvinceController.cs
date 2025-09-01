
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
public class ProvinceController : BaseController
{
    public ProvinceController(IProvince_Service provinceService)
    {
        this.provinceService = provinceService;
    }

    private IProvince_Service provinceService { get; set; }

    [HttpGet]
    [Route("Province/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.provinceService.RetrieveById(id, Province.Informer, this.UserCredit);

        return result.ToActionResult<Province>();
    }

    [HttpGet]
    [Route("Province/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.provinceService.RetrieveAll(Province.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Province>();
    }
            

    
    [HttpPost]
    [Route("Province/Save")]
    public async Task<IActionResult> Save([FromBody] Province province)
    {
        var result = await this.provinceService.Save(province, this.UserCredit);

        return result.ToActionResult<Province>();
    }

    
    [HttpPost]
    [Route("Province/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Province province)
    {
        var result = await this.provinceService.SaveAttached(province, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Province/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Province> provinceList)
    {
        var result = await this.provinceService.SaveBulk(provinceList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Province/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Province province, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.provinceService.Seek(province, this.UserCredit, pageNumber);

        return result.ToActionResult<Province>();
    }

    [HttpGet]
    [Route("Province/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.provinceService.SeekByValue(seekValue, Province.Informer);

        return result.ToActionResult<Province>();
    }

    [HttpDelete]
    [Route("Province/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Province province)
    {
        var result = await this.provinceService.Delete(province, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Province.CollectionOfCity
    [HttpPost]
    [Route("Province/{province_id:int}/City")]
    public IActionResult CollectionOfCity([FromRoute(Name = "province_id")] int id, [FromBody] City city)
    {
        return this.provinceService.CollectionOfCity(id, city, this.UserCredit).ToActionResult();
    }
}
