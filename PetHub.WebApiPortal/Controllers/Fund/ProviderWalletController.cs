
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
public class ProviderWalletController : BaseController
{
    public ProviderWalletController(IProviderWallet_Service providerWalletService)
    {
        this.providerWalletService = providerWalletService;
    }

    private IProviderWallet_Service providerWalletService { get; set; }

    [HttpGet]
    [Route("ProviderWallet/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerWalletService.RetrieveById(id, ProviderWallet.Informer, this.UserCredit);

        return result.ToActionResult<ProviderWallet>();
    }

    [HttpGet]
    [Route("ProviderWallet/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerWalletService.RetrieveAll(ProviderWallet.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ProviderWallet>();
    }
            

    
    [HttpPost]
    [Route("ProviderWallet/Save")]
    public async Task<IActionResult> Save([FromBody] ProviderWallet providerWallet)
    {
        var result = await this.providerWalletService.Save(providerWallet, this.UserCredit);

        return result.ToActionResult<ProviderWallet>();
    }

    
    [HttpPost]
    [Route("ProviderWallet/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ProviderWallet providerWallet)
    {
        var result = await this.providerWalletService.SaveAttached(providerWallet, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ProviderWallet/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ProviderWallet> providerWalletList)
    {
        var result = await this.providerWalletService.SaveBulk(providerWalletList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ProviderWallet/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ProviderWallet providerWallet, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerWalletService.Seek(providerWallet, this.UserCredit, pageNumber);

        return result.ToActionResult<ProviderWallet>();
    }

    [HttpGet]
    [Route("ProviderWallet/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerWalletService.SeekByValue(seekValue, ProviderWallet.Informer);

        return result.ToActionResult<ProviderWallet>();
    }

    [HttpDelete]
    [Route("ProviderWallet/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ProviderWallet providerWallet)
    {
        var result = await this.providerWalletService.Delete(providerWallet, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// ProviderWallet.CollectionOfBookingTransaction
    [HttpPost]
    [Route("ProviderWallet/{providerWallet_id:int}/BookingTransaction")]
    public IActionResult CollectionOfBookingTransaction([FromRoute(Name = "providerWallet_id")] int id, [FromBody] BookingTransaction bookingTransaction)
    {
        return this.providerWalletService.CollectionOfBookingTransaction(id, bookingTransaction, this.UserCredit).ToActionResult();
    }
}
