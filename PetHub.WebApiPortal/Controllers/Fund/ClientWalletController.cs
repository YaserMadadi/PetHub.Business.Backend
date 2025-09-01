
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
public class ClientWalletController : BaseController
{
    public ClientWalletController(IClientWallet_Service clientWalletService)
    {
        this.clientWalletService = clientWalletService;
    }

    private IClientWallet_Service clientWalletService { get; set; }

    [HttpGet]
    [Route("ClientWallet/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.clientWalletService.RetrieveById(id, ClientWallet.Informer, this.UserCredit);

        return result.ToActionResult<ClientWallet>();
    }

    [HttpGet]
    [Route("ClientWallet/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.clientWalletService.RetrieveAll(ClientWallet.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ClientWallet>();
    }
            

    
    [HttpPost]
    [Route("ClientWallet/Save")]
    public async Task<IActionResult> Save([FromBody] ClientWallet clientWallet)
    {
        var result = await this.clientWalletService.Save(clientWallet, this.UserCredit);

        return result.ToActionResult<ClientWallet>();
    }

    
    [HttpPost]
    [Route("ClientWallet/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ClientWallet clientWallet)
    {
        var result = await this.clientWalletService.SaveAttached(clientWallet, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ClientWallet/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ClientWallet> clientWalletList)
    {
        var result = await this.clientWalletService.SaveBulk(clientWalletList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ClientWallet/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ClientWallet clientWallet, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.clientWalletService.Seek(clientWallet, this.UserCredit, pageNumber);

        return result.ToActionResult<ClientWallet>();
    }

    [HttpGet]
    [Route("ClientWallet/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.clientWalletService.SeekByValue(seekValue, ClientWallet.Informer);

        return result.ToActionResult<ClientWallet>();
    }

    [HttpDelete]
    [Route("ClientWallet/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ClientWallet clientWallet)
    {
        var result = await this.clientWalletService.Delete(clientWallet, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// ClientWallet.CollectionOfBookingTransaction
    [HttpPost]
    [Route("ClientWallet/{clientWallet_id:int}/BookingTransaction")]
    public IActionResult CollectionOfBookingTransaction([FromRoute(Name = "clientWallet_id")] int id, [FromBody] BookingTransaction bookingTransaction)
    {
        return this.clientWalletService.CollectionOfBookingTransaction(id, bookingTransaction, this.UserCredit).ToActionResult();
    }

		//// ClientWallet.CollectionOfClientWalletTransactionLog
    [HttpPost]
    [Route("ClientWallet/{clientWallet_id:int}/ClientWalletTransactionLog")]
    public IActionResult CollectionOfClientWalletTransactionLog([FromRoute(Name = "clientWallet_id")] int id, [FromBody] ClientWalletTransactionLog clientWalletTransactionLog)
    {
        return this.clientWalletService.CollectionOfClientWalletTransactionLog(id, clientWalletTransactionLog, this.UserCredit).ToActionResult();
    }

		//// ClientWallet.CollectionOfWalletTopUp
    [HttpPost]
    [Route("ClientWallet/{clientWallet_id:int}/WalletTopUp")]
    public IActionResult CollectionOfWalletTopUp([FromRoute(Name = "clientWallet_id")] int id, [FromBody] WalletTopUp walletTopUp)
    {
        return this.clientWalletService.CollectionOfWalletTopUp(id, walletTopUp, this.UserCredit).ToActionResult();
    }
}
