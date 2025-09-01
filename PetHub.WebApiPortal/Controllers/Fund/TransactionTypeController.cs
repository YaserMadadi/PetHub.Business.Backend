
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
public class TransactionTypeController : BaseController
{
    public TransactionTypeController(ITransactionType_Service transactionTypeService)
    {
        this.transactionTypeService = transactionTypeService;
    }

    private ITransactionType_Service transactionTypeService { get; set; }

    [HttpGet]
    [Route("TransactionType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.transactionTypeService.RetrieveById(id, TransactionType.Informer, this.UserCredit);

        return result.ToActionResult<TransactionType>();
    }

    [HttpGet]
    [Route("TransactionType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.transactionTypeService.RetrieveAll(TransactionType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<TransactionType>();
    }
            

    
    [HttpPost]
    [Route("TransactionType/Save")]
    public async Task<IActionResult> Save([FromBody] TransactionType transactionType)
    {
        var result = await this.transactionTypeService.Save(transactionType, this.UserCredit);

        return result.ToActionResult<TransactionType>();
    }

    
    [HttpPost]
    [Route("TransactionType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] TransactionType transactionType)
    {
        var result = await this.transactionTypeService.SaveAttached(transactionType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("TransactionType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<TransactionType> transactionTypeList)
    {
        var result = await this.transactionTypeService.SaveBulk(transactionTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("TransactionType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] TransactionType transactionType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.transactionTypeService.Seek(transactionType, this.UserCredit, pageNumber);

        return result.ToActionResult<TransactionType>();
    }

    [HttpGet]
    [Route("TransactionType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.transactionTypeService.SeekByValue(seekValue, TransactionType.Informer);

        return result.ToActionResult<TransactionType>();
    }

    [HttpDelete]
    [Route("TransactionType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] TransactionType transactionType)
    {
        var result = await this.transactionTypeService.Delete(transactionType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// TransactionType.CollectionOfClientWalletTransactionLog
    [HttpPost]
    [Route("TransactionType/{transactionType_id:int}/ClientWalletTransactionLog")]
    public IActionResult CollectionOfClientWalletTransactionLog([FromRoute(Name = "transactionType_id")] int id, [FromBody] ClientWalletTransactionLog clientWalletTransactionLog)
    {
        return this.transactionTypeService.CollectionOfClientWalletTransactionLog(id, clientWalletTransactionLog, this.UserCredit).ToActionResult();
    }
}
