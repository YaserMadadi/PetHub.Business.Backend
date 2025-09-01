
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
public class PetBehaviorController : BaseController
{
    public PetBehaviorController(IPetBehavior_Service petBehaviorService)
    {
        this.petBehaviorService = petBehaviorService;
    }

    private IPetBehavior_Service petBehaviorService { get; set; }

    [HttpGet]
    [Route("PetBehavior/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.petBehaviorService.RetrieveById(id, PetBehavior.Informer, this.UserCredit);

        return result.ToActionResult<PetBehavior>();
    }

    [HttpGet]
    [Route("PetBehavior/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.petBehaviorService.RetrieveAll(PetBehavior.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<PetBehavior>();
    }
            

    
    [HttpPost]
    [Route("PetBehavior/Save")]
    public async Task<IActionResult> Save([FromBody] PetBehavior petBehavior)
    {
        var result = await this.petBehaviorService.Save(petBehavior, this.UserCredit);

        return result.ToActionResult<PetBehavior>();
    }

    
    [HttpPost]
    [Route("PetBehavior/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] PetBehavior petBehavior)
    {
        var result = await this.petBehaviorService.SaveAttached(petBehavior, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("PetBehavior/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<PetBehavior> petBehaviorList)
    {
        var result = await this.petBehaviorService.SaveBulk(petBehaviorList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("PetBehavior/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] PetBehavior petBehavior, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.petBehaviorService.Seek(petBehavior, this.UserCredit, pageNumber);

        return result.ToActionResult<PetBehavior>();
    }

    [HttpGet]
    [Route("PetBehavior/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.petBehaviorService.SeekByValue(seekValue, PetBehavior.Informer);

        return result.ToActionResult<PetBehavior>();
    }

    [HttpDelete]
    [Route("PetBehavior/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PetBehavior petBehavior)
    {
        var result = await this.petBehaviorService.Delete(petBehavior, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
