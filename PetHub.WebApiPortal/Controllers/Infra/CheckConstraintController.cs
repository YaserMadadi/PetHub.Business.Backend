
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Infra.Abstract;
using PetHub.Entities.Infra;

namespace PetHub.ApiServices.Controllers.Infra;

[Route("api/Infra")]
public class CheckConstraintController : BaseController
{
    public CheckConstraintController(ICheckConstraint_Service checkConstraintService)
    {
        this.checkConstraintService = checkConstraintService;
    }

    private ICheckConstraint_Service checkConstraintService { get; set; }

    [HttpGet]
    [Route("CheckConstraint/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.checkConstraintService.RetrieveById(id, CheckConstraint.Informer, this.UserCredit);

        return result.ToActionResult<CheckConstraint>();
    }

    [HttpGet]
    [Route("CheckConstraint/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.checkConstraintService.RetrieveAll(CheckConstraint.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<CheckConstraint>();
    }
            

    
    [HttpPost]
    [Route("CheckConstraint/Save")]
    public async Task<IActionResult> Save([FromBody] CheckConstraint checkConstraint)
    {
        var result = await this.checkConstraintService.Save(checkConstraint, this.UserCredit);

        return result.ToActionResult<CheckConstraint>();
    }

    
    [HttpPost]
    [Route("CheckConstraint/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] CheckConstraint checkConstraint)
    {
        var result = await this.checkConstraintService.SaveAttached(checkConstraint, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("CheckConstraint/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<CheckConstraint> checkConstraintList)
    {
        var result = await this.checkConstraintService.SaveBulk(checkConstraintList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("CheckConstraint/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] CheckConstraint checkConstraint, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.checkConstraintService.Seek(checkConstraint, this.UserCredit, pageNumber);

        return result.ToActionResult<CheckConstraint>();
    }

    [HttpGet]
    [Route("CheckConstraint/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.checkConstraintService.SeekByValue(seekValue, CheckConstraint.Informer);

        return result.ToActionResult<CheckConstraint>();
    }

    [HttpDelete]
    [Route("CheckConstraint/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CheckConstraint checkConstraint)
    {
        var result = await this.checkConstraintService.Delete(checkConstraint, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
