
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
public class AccountStatusController : BaseController
{
    public AccountStatusController(IAccountStatus_Service accountStatusService)
    {
        this.accountStatusService = accountStatusService;
    }

    private IAccountStatus_Service accountStatusService { get; set; }

    [HttpGet]
    [Route("AccountStatus/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.accountStatusService.RetrieveById(id, AccountStatus.Informer, this.UserCredit);

        return result.ToActionResult<AccountStatus>();
    }

    [HttpGet]
    [Route("AccountStatus/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.accountStatusService.RetrieveAll(AccountStatus.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<AccountStatus>();
    }
            

    
    [HttpPost]
    [Route("AccountStatus/Save")]
    public async Task<IActionResult> Save([FromBody] AccountStatus accountStatus)
    {
        var result = await this.accountStatusService.Save(accountStatus, this.UserCredit);

        return result.ToActionResult<AccountStatus>();
    }

    
    [HttpPost]
    [Route("AccountStatus/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] AccountStatus accountStatus)
    {
        var result = await this.accountStatusService.SaveAttached(accountStatus, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("AccountStatus/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<AccountStatus> accountStatusList)
    {
        var result = await this.accountStatusService.SaveBulk(accountStatusList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("AccountStatus/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] AccountStatus accountStatus, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.accountStatusService.Seek(accountStatus, this.UserCredit, pageNumber);

        return result.ToActionResult<AccountStatus>();
    }

    [HttpGet]
    [Route("AccountStatus/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.accountStatusService.SeekByValue(seekValue, AccountStatus.Informer);

        return result.ToActionResult<AccountStatus>();
    }

    [HttpDelete]
    [Route("AccountStatus/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AccountStatus accountStatus)
    {
        var result = await this.accountStatusService.Delete(accountStatus, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// AccountStatus.CollectionOfUserAccount
    [HttpPost]
    [Route("AccountStatus/{accountStatus_id:int}/UserAccount")]
    public IActionResult CollectionOfUserAccount([FromRoute(Name = "accountStatus_id")] int id, [FromBody] UserAccount userAccount)
    {
        return this.accountStatusService.CollectionOfUserAccount(id, userAccount, this.UserCredit).ToActionResult();
    }
}
