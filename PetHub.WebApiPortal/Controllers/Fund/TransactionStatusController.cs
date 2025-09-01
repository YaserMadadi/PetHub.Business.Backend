
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
public class TransactionStatusController : BaseController
{
    public TransactionStatusController(ITransactionStatus_Service transactionStatusService)
    {
        this.transactionStatusService = transactionStatusService;
    }

    private ITransactionStatus_Service transactionStatusService { get; set; }

    [HttpGet]
    [Route("TransactionStatus/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.transactionStatusService.RetrieveById(id, TransactionStatus.Informer, this.UserCredit);

        return result.ToActionResult<TransactionStatus>();
    }

    [HttpGet]
    [Route("TransactionStatus/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.transactionStatusService.RetrieveAll(TransactionStatus.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<TransactionStatus>();
    }
            

    
    [HttpPost]
    [Route("TransactionStatus/Save")]
    public async Task<IActionResult> Save([FromBody] TransactionStatus transactionStatus)
    {
        var result = await this.transactionStatusService.Save(transactionStatus, this.UserCredit);

        return result.ToActionResult<TransactionStatus>();
    }

    
    [HttpPost]
    [Route("TransactionStatus/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] TransactionStatus transactionStatus)
    {
        var result = await this.transactionStatusService.SaveAttached(transactionStatus, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("TransactionStatus/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<TransactionStatus> transactionStatusList)
    {
        var result = await this.transactionStatusService.SaveBulk(transactionStatusList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("TransactionStatus/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] TransactionStatus transactionStatus, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.transactionStatusService.Seek(transactionStatus, this.UserCredit, pageNumber);

        return result.ToActionResult<TransactionStatus>();
    }

    [HttpGet]
    [Route("TransactionStatus/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.transactionStatusService.SeekByValue(seekValue, TransactionStatus.Informer);

        return result.ToActionResult<TransactionStatus>();
    }

    [HttpDelete]
    [Route("TransactionStatus/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] TransactionStatus transactionStatus)
    {
        var result = await this.transactionStatusService.Delete(transactionStatus, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// TransactionStatus.CollectionOfClientWalletTransactionLog
    [HttpPost]
    [Route("TransactionStatus/{transactionStatus_id:int}/ClientWalletTransactionLog")]
    public IActionResult CollectionOfClientWalletTransactionLog([FromRoute(Name = "transactionStatus_id")] int id, [FromBody] ClientWalletTransactionLog clientWalletTransactionLog)
    {
        return this.transactionStatusService.CollectionOfClientWalletTransactionLog(id, clientWalletTransactionLog, this.UserCredit).ToActionResult();
    }

		//// TransactionStatus.CollectionOfProviderPayOut
    [HttpPost]
    [Route("TransactionStatus/{transactionStatus_id:int}/ProviderPayOut")]
    public IActionResult CollectionOfProviderPayOut([FromRoute(Name = "transactionStatus_id")] int id, [FromBody] ProviderPayOut providerPayOut)
    {
        return this.transactionStatusService.CollectionOfProviderPayOut(id, providerPayOut, this.UserCredit).ToActionResult();
    }

		//// TransactionStatus.CollectionOfWalletTopUp
    [HttpPost]
    [Route("TransactionStatus/{transactionStatus_id:int}/WalletTopUp")]
    public IActionResult CollectionOfWalletTopUp([FromRoute(Name = "transactionStatus_id")] int id, [FromBody] WalletTopUp walletTopUp)
    {
        return this.transactionStatusService.CollectionOfWalletTopUp(id, walletTopUp, this.UserCredit).ToActionResult();
    }
}
