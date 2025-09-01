
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
public class ExceptionProcedureController : BaseController
{
    public ExceptionProcedureController(IExceptionProcedure_Service exceptionProcedureService)
    {
        this.exceptionProcedureService = exceptionProcedureService;
    }

    private IExceptionProcedure_Service exceptionProcedureService { get; set; }

    [HttpGet]
    [Route("ExceptionProcedure/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.exceptionProcedureService.RetrieveById(id, ExceptionProcedure.Informer, this.UserCredit);

        return result.ToActionResult<ExceptionProcedure>();
    }

    [HttpGet]
    [Route("ExceptionProcedure/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.exceptionProcedureService.RetrieveAll(ExceptionProcedure.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ExceptionProcedure>();
    }
            

    
    [HttpPost]
    [Route("ExceptionProcedure/Save")]
    public async Task<IActionResult> Save([FromBody] ExceptionProcedure exceptionProcedure)
    {
        var result = await this.exceptionProcedureService.Save(exceptionProcedure, this.UserCredit);

        return result.ToActionResult<ExceptionProcedure>();
    }

    
    [HttpPost]
    [Route("ExceptionProcedure/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ExceptionProcedure exceptionProcedure)
    {
        var result = await this.exceptionProcedureService.SaveAttached(exceptionProcedure, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ExceptionProcedure/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ExceptionProcedure> exceptionProcedureList)
    {
        var result = await this.exceptionProcedureService.SaveBulk(exceptionProcedureList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ExceptionProcedure/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ExceptionProcedure exceptionProcedure, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.exceptionProcedureService.Seek(exceptionProcedure, this.UserCredit, pageNumber);

        return result.ToActionResult<ExceptionProcedure>();
    }

    [HttpGet]
    [Route("ExceptionProcedure/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.exceptionProcedureService.SeekByValue(seekValue, ExceptionProcedure.Informer);

        return result.ToActionResult<ExceptionProcedure>();
    }

    [HttpDelete]
    [Route("ExceptionProcedure/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ExceptionProcedure exceptionProcedure)
    {
        var result = await this.exceptionProcedureService.Delete(exceptionProcedure, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
