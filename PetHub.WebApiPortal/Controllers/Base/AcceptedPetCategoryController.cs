
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
public class AcceptedPetCategoryController : BaseController
{
    public AcceptedPetCategoryController(IAcceptedPetCategory_Service acceptedPetCategoryService)
    {
        this.acceptedPetCategoryService = acceptedPetCategoryService;
    }

    private IAcceptedPetCategory_Service acceptedPetCategoryService { get; set; }

    [HttpGet]
    [Route("AcceptedPetCategory/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.acceptedPetCategoryService.RetrieveById(id, AcceptedPetCategory.Informer, this.UserCredit);

        return result.ToActionResult<AcceptedPetCategory>();
    }

    [HttpGet]
    [Route("AcceptedPetCategory/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.acceptedPetCategoryService.RetrieveAll(AcceptedPetCategory.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<AcceptedPetCategory>();
    }
            

    
    [HttpPost]
    [Route("AcceptedPetCategory/Save")]
    public async Task<IActionResult> Save([FromBody] AcceptedPetCategory acceptedPetCategory)
    {
        var result = await this.acceptedPetCategoryService.Save(acceptedPetCategory, this.UserCredit);

        return result.ToActionResult<AcceptedPetCategory>();
    }

    
    [HttpPost]
    [Route("AcceptedPetCategory/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] AcceptedPetCategory acceptedPetCategory)
    {
        var result = await this.acceptedPetCategoryService.SaveAttached(acceptedPetCategory, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("AcceptedPetCategory/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<AcceptedPetCategory> acceptedPetCategoryList)
    {
        var result = await this.acceptedPetCategoryService.SaveBulk(acceptedPetCategoryList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("AcceptedPetCategory/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] AcceptedPetCategory acceptedPetCategory, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.acceptedPetCategoryService.Seek(acceptedPetCategory, this.UserCredit, pageNumber);

        return result.ToActionResult<AcceptedPetCategory>();
    }

    [HttpGet]
    [Route("AcceptedPetCategory/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.acceptedPetCategoryService.SeekByValue(seekValue, AcceptedPetCategory.Informer);

        return result.ToActionResult<AcceptedPetCategory>();
    }

    [HttpDelete]
    [Route("AcceptedPetCategory/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AcceptedPetCategory acceptedPetCategory)
    {
        var result = await this.acceptedPetCategoryService.Delete(acceptedPetCategory, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
