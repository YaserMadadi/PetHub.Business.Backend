
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
public class WalletTopUpController : BaseController
{
    public WalletTopUpController(IWalletTopUp_Service walletTopUpService)
    {
        this.walletTopUpService = walletTopUpService;
    }

    private IWalletTopUp_Service walletTopUpService { get; set; }

    [HttpGet]
    [Route("WalletTopUp/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.walletTopUpService.RetrieveById(id, WalletTopUp.Informer, this.UserCredit);

        return result.ToActionResult<WalletTopUp>();
    }

    [HttpGet]
    [Route("WalletTopUp/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.walletTopUpService.RetrieveAll(WalletTopUp.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<WalletTopUp>();
    }
            

    
    [HttpPost]
    [Route("WalletTopUp/Save")]
    public async Task<IActionResult> Save([FromBody] WalletTopUp walletTopUp)
    {
        var result = await this.walletTopUpService.Save(walletTopUp, this.UserCredit);

        return result.ToActionResult<WalletTopUp>();
    }

    
    [HttpPost]
    [Route("WalletTopUp/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] WalletTopUp walletTopUp)
    {
        var result = await this.walletTopUpService.SaveAttached(walletTopUp, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("WalletTopUp/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<WalletTopUp> walletTopUpList)
    {
        var result = await this.walletTopUpService.SaveBulk(walletTopUpList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("WalletTopUp/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] WalletTopUp walletTopUp, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.walletTopUpService.Seek(walletTopUp, this.UserCredit, pageNumber);

        return result.ToActionResult<WalletTopUp>();
    }

    [HttpGet]
    [Route("WalletTopUp/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.walletTopUpService.SeekByValue(seekValue, WalletTopUp.Informer);

        return result.ToActionResult<WalletTopUp>();
    }

    [HttpDelete]
    [Route("WalletTopUp/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] WalletTopUp walletTopUp)
    {
        var result = await this.walletTopUpService.Delete(walletTopUp, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
