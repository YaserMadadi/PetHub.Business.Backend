
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
public class ExceptionBackendController : BaseController
{
    public ExceptionBackendController(IExceptionBackend_Service exceptionBackendService)
    {
        this.exceptionBackendService = exceptionBackendService;
    }

    private IExceptionBackend_Service exceptionBackendService { get; set; }

    [HttpGet]
    [Route("ExceptionBackend/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.exceptionBackendService.RetrieveById(id, ExceptionBackend.Informer, this.UserCredit);

        return result.ToActionResult<ExceptionBackend>();
    }

    [HttpGet]
    [Route("ExceptionBackend/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.exceptionBackendService.RetrieveAll(ExceptionBackend.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ExceptionBackend>();
    }
            

    
    [HttpPost]
    [Route("ExceptionBackend/Save")]
    public async Task<IActionResult> Save([FromBody] ExceptionBackend exceptionBackend)
    {
        var result = await this.exceptionBackendService.Save(exceptionBackend, this.UserCredit);

        return result.ToActionResult<ExceptionBackend>();
    }

    
    [HttpPost]
    [Route("ExceptionBackend/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ExceptionBackend exceptionBackend)
    {
        var result = await this.exceptionBackendService.SaveAttached(exceptionBackend, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ExceptionBackend/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ExceptionBackend> exceptionBackendList)
    {
        var result = await this.exceptionBackendService.SaveBulk(exceptionBackendList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ExceptionBackend/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ExceptionBackend exceptionBackend, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.exceptionBackendService.Seek(exceptionBackend, this.UserCredit, pageNumber);

        return result.ToActionResult<ExceptionBackend>();
    }

    [HttpGet]
    [Route("ExceptionBackend/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.exceptionBackendService.SeekByValue(seekValue, ExceptionBackend.Informer);

        return result.ToActionResult<ExceptionBackend>();
    }

    [HttpDelete]
    [Route("ExceptionBackend/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ExceptionBackend exceptionBackend)
    {
        var result = await this.exceptionBackendService.Delete(exceptionBackend, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
