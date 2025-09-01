
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
public class ProviderBankAccountController : BaseController
{
    public ProviderBankAccountController(IProviderBankAccount_Service providerBankAccountService)
    {
        this.providerBankAccountService = providerBankAccountService;
    }

    private IProviderBankAccount_Service providerBankAccountService { get; set; }

    [HttpGet]
    [Route("ProviderBankAccount/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerBankAccountService.RetrieveById(id, ProviderBankAccount.Informer, this.UserCredit);

        return result.ToActionResult<ProviderBankAccount>();
    }

    [HttpGet]
    [Route("ProviderBankAccount/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerBankAccountService.RetrieveAll(ProviderBankAccount.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ProviderBankAccount>();
    }
            

    
    [HttpPost]
    [Route("ProviderBankAccount/Save")]
    public async Task<IActionResult> Save([FromBody] ProviderBankAccount providerBankAccount)
    {
        var result = await this.providerBankAccountService.Save(providerBankAccount, this.UserCredit);

        return result.ToActionResult<ProviderBankAccount>();
    }

    
    [HttpPost]
    [Route("ProviderBankAccount/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ProviderBankAccount providerBankAccount)
    {
        var result = await this.providerBankAccountService.SaveAttached(providerBankAccount, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ProviderBankAccount/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ProviderBankAccount> providerBankAccountList)
    {
        var result = await this.providerBankAccountService.SaveBulk(providerBankAccountList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ProviderBankAccount/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ProviderBankAccount providerBankAccount, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerBankAccountService.Seek(providerBankAccount, this.UserCredit, pageNumber);

        return result.ToActionResult<ProviderBankAccount>();
    }

    [HttpGet]
    [Route("ProviderBankAccount/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerBankAccountService.SeekByValue(seekValue, ProviderBankAccount.Informer);

        return result.ToActionResult<ProviderBankAccount>();
    }

    [HttpDelete]
    [Route("ProviderBankAccount/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ProviderBankAccount providerBankAccount)
    {
        var result = await this.providerBankAccountService.Delete(providerBankAccount, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
