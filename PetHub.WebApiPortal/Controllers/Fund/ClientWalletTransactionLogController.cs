
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Fund.Abstract;
using PetHub.Entities.Fund;

namespace PetHub.ApiServices.Controllers.Fund;

[Route("api/Fund")]
public class ClientWalletTransactionLogController : BaseController
{
    public ClientWalletTransactionLogController(IClientWalletTransactionLog_Service clientWalletTransactionLogService)
    {
        this.clientWalletTransactionLogService = clientWalletTransactionLogService;
    }

    private IClientWalletTransactionLog_Service clientWalletTransactionLogService { get; set; }

    [HttpGet]
    [Route("ClientWalletTransactionLog/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.clientWalletTransactionLogService.RetrieveById(id, ClientWalletTransactionLog.Informer, this.UserCredit);

        return result.ToActionResult<ClientWalletTransactionLog>();
    }

    [HttpGet]
    [Route("ClientWalletTransactionLog/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.clientWalletTransactionLogService.RetrieveAll(ClientWalletTransactionLog.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ClientWalletTransactionLog>();
    }
            

    
    [HttpPost]
    [Route("ClientWalletTransactionLog/Save")]
    public async Task<IActionResult> Save([FromBody] ClientWalletTransactionLog clientWalletTransactionLog)
    {
        var result = await this.clientWalletTransactionLogService.Save(clientWalletTransactionLog, this.UserCredit);

        return result.ToActionResult<ClientWalletTransactionLog>();
    }

    
    [HttpPost]
    [Route("ClientWalletTransactionLog/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ClientWalletTransactionLog clientWalletTransactionLog)
    {
        var result = await this.clientWalletTransactionLogService.SaveAttached(clientWalletTransactionLog, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ClientWalletTransactionLog/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ClientWalletTransactionLog> clientWalletTransactionLogList)
    {
        var result = await this.clientWalletTransactionLogService.SaveBulk(clientWalletTransactionLogList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ClientWalletTransactionLog/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ClientWalletTransactionLog clientWalletTransactionLog, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.clientWalletTransactionLogService.Seek(clientWalletTransactionLog, this.UserCredit, pageNumber);

        return result.ToActionResult<ClientWalletTransactionLog>();
    }

    [HttpGet]
    [Route("ClientWalletTransactionLog/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.clientWalletTransactionLogService.SeekByValue(seekValue, ClientWalletTransactionLog.Informer);

        return result.ToActionResult<ClientWalletTransactionLog>();
    }

    [HttpDelete]
    [Route("ClientWalletTransactionLog/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ClientWalletTransactionLog clientWalletTransactionLog)
    {
        var result = await this.clientWalletTransactionLogService.Delete(clientWalletTransactionLog, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
