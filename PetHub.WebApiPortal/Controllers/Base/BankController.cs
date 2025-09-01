
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
public class BankController : BaseController
{
    public BankController(IBank_Service bankService)
    {
        this.bankService = bankService;
    }

    private IBank_Service bankService { get; set; }

    [HttpGet]
    [Route("Bank/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.bankService.RetrieveById(id, Bank.Informer, this.UserCredit);

        return result.ToActionResult<Bank>();
    }

    [HttpGet]
    [Route("Bank/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.bankService.RetrieveAll(Bank.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Bank>();
    }
            

    
    [HttpPost]
    [Route("Bank/Save")]
    public async Task<IActionResult> Save([FromBody] Bank bank)
    {
        var result = await this.bankService.Save(bank, this.UserCredit);

        return result.ToActionResult<Bank>();
    }

    
    [HttpPost]
    [Route("Bank/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Bank bank)
    {
        var result = await this.bankService.SaveAttached(bank, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Bank/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Bank> bankList)
    {
        var result = await this.bankService.SaveBulk(bankList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Bank/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Bank bank, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.bankService.Seek(bank, this.UserCredit, pageNumber);

        return result.ToActionResult<Bank>();
    }

    [HttpGet]
    [Route("Bank/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.bankService.SeekByValue(seekValue, Bank.Informer);

        return result.ToActionResult<Bank>();
    }

    [HttpDelete]
    [Route("Bank/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Bank bank)
    {
        var result = await this.bankService.Delete(bank, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Bank.CollectionOfProviderBankAccount
    [HttpPost]
    [Route("Bank/{bank_id:int}/ProviderBankAccount")]
    public IActionResult CollectionOfProviderBankAccount([FromRoute(Name = "bank_id")] int id, [FromBody] ProviderBankAccount providerBankAccount)
    {
        return this.bankService.CollectionOfProviderBankAccount(id, providerBankAccount, this.UserCredit).ToActionResult();
    }
}
