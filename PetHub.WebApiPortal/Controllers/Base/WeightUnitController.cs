
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
public class WeightUnitController : BaseController
{
    public WeightUnitController(IWeightUnit_Service weightUnitService)
    {
        this.weightUnitService = weightUnitService;
    }

    private IWeightUnit_Service weightUnitService { get; set; }

    [HttpGet]
    [Route("WeightUnit/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.weightUnitService.RetrieveById(id, WeightUnit.Informer, this.UserCredit);

        return result.ToActionResult<WeightUnit>();
    }

    [HttpGet]
    [Route("WeightUnit/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.weightUnitService.RetrieveAll(WeightUnit.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<WeightUnit>();
    }
            

    
    [HttpPost]
    [Route("WeightUnit/Save")]
    public async Task<IActionResult> Save([FromBody] WeightUnit weightUnit)
    {
        var result = await this.weightUnitService.Save(weightUnit, this.UserCredit);

        return result.ToActionResult<WeightUnit>();
    }

    
    [HttpPost]
    [Route("WeightUnit/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] WeightUnit weightUnit)
    {
        var result = await this.weightUnitService.SaveAttached(weightUnit, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("WeightUnit/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<WeightUnit> weightUnitList)
    {
        var result = await this.weightUnitService.SaveBulk(weightUnitList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("WeightUnit/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] WeightUnit weightUnit, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.weightUnitService.Seek(weightUnit, this.UserCredit, pageNumber);

        return result.ToActionResult<WeightUnit>();
    }

    [HttpGet]
    [Route("WeightUnit/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.weightUnitService.SeekByValue(seekValue, WeightUnit.Informer);

        return result.ToActionResult<WeightUnit>();
    }

    [HttpDelete]
    [Route("WeightUnit/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] WeightUnit weightUnit)
    {
        var result = await this.weightUnitService.Delete(weightUnit, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// WeightUnit.CollectionOfPet
    [HttpPost]
    [Route("WeightUnit/{weightUnit_id:int}/Pet")]
    public IActionResult CollectionOfPet([FromRoute(Name = "weightUnit_id")] int id, [FromBody] Pet pet)
    {
        return this.weightUnitService.CollectionOfPet(id, pet, this.UserCredit).ToActionResult();
    }
}
