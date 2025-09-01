
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
public class BehaviorCategoryController : BaseController
{
    public BehaviorCategoryController(IBehaviorCategory_Service behaviorCategoryService)
    {
        this.behaviorCategoryService = behaviorCategoryService;
    }

    private IBehaviorCategory_Service behaviorCategoryService { get; set; }

    [HttpGet]
    [Route("BehaviorCategory/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.behaviorCategoryService.RetrieveById(id, BehaviorCategory.Informer, this.UserCredit);

        return result.ToActionResult<BehaviorCategory>();
    }

    [HttpGet]
    [Route("BehaviorCategory/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.behaviorCategoryService.RetrieveAll(BehaviorCategory.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<BehaviorCategory>();
    }
            

    
    [HttpPost]
    [Route("BehaviorCategory/Save")]
    public async Task<IActionResult> Save([FromBody] BehaviorCategory behaviorCategory)
    {
        var result = await this.behaviorCategoryService.Save(behaviorCategory, this.UserCredit);

        return result.ToActionResult<BehaviorCategory>();
    }

    
    [HttpPost]
    [Route("BehaviorCategory/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] BehaviorCategory behaviorCategory)
    {
        var result = await this.behaviorCategoryService.SaveAttached(behaviorCategory, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("BehaviorCategory/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<BehaviorCategory> behaviorCategoryList)
    {
        var result = await this.behaviorCategoryService.SaveBulk(behaviorCategoryList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("BehaviorCategory/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] BehaviorCategory behaviorCategory, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.behaviorCategoryService.Seek(behaviorCategory, this.UserCredit, pageNumber);

        return result.ToActionResult<BehaviorCategory>();
    }

    [HttpGet]
    [Route("BehaviorCategory/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.behaviorCategoryService.SeekByValue(seekValue, BehaviorCategory.Informer);

        return result.ToActionResult<BehaviorCategory>();
    }

    [HttpDelete]
    [Route("BehaviorCategory/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BehaviorCategory behaviorCategory)
    {
        var result = await this.behaviorCategoryService.Delete(behaviorCategory, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// BehaviorCategory.CollectionOfPetBehavior
    [HttpPost]
    [Route("BehaviorCategory/{behaviorCategory_id:int}/PetBehavior")]
    public IActionResult CollectionOfPetBehavior([FromRoute(Name = "behaviorCategory_id")] int id, [FromBody] PetBehavior petBehavior)
    {
        return this.behaviorCategoryService.CollectionOfPetBehavior(id, petBehavior, this.UserCredit).ToActionResult();
    }
}
