
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
public class PetCategoryController : BaseController
{
    public PetCategoryController(IPetCategory_Service petCategoryService)
    {
        this.petCategoryService = petCategoryService;
    }

    private IPetCategory_Service petCategoryService { get; set; }

    [HttpGet]
    [Route("PetCategory/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.petCategoryService.RetrieveById(id, PetCategory.Informer, this.UserCredit);

        return result.ToActionResult<PetCategory>();
    }

    [HttpGet]
    [Route("PetCategory/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.petCategoryService.RetrieveAll(PetCategory.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<PetCategory>();
    }
            

    
    [HttpPost]
    [Route("PetCategory/Save")]
    public async Task<IActionResult> Save([FromBody] PetCategory petCategory)
    {
        var result = await this.petCategoryService.Save(petCategory, this.UserCredit);

        return result.ToActionResult<PetCategory>();
    }

    
    [HttpPost]
    [Route("PetCategory/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] PetCategory petCategory)
    {
        var result = await this.petCategoryService.SaveAttached(petCategory, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("PetCategory/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<PetCategory> petCategoryList)
    {
        var result = await this.petCategoryService.SaveBulk(petCategoryList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("PetCategory/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] PetCategory petCategory, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.petCategoryService.Seek(petCategory, this.UserCredit, pageNumber);

        return result.ToActionResult<PetCategory>();
    }

    [HttpGet]
    [Route("PetCategory/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.petCategoryService.SeekByValue(seekValue, PetCategory.Informer);

        return result.ToActionResult<PetCategory>();
    }

    [HttpDelete]
    [Route("PetCategory/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PetCategory petCategory)
    {
        var result = await this.petCategoryService.Delete(petCategory, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// PetCategory.CollectionOfAcceptedPetCategory
    [HttpPost]
    [Route("PetCategory/{petCategory_id:int}/AcceptedPetCategory")]
    public IActionResult CollectionOfAcceptedPetCategory([FromRoute(Name = "petCategory_id")] int id, [FromBody] AcceptedPetCategory acceptedPetCategory)
    {
        return this.petCategoryService.CollectionOfAcceptedPetCategory(id, acceptedPetCategory, this.UserCredit).ToActionResult();
    }
}
