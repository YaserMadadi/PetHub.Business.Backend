
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Base;
using PetHub.Entities.Admin;

namespace PetHub.ApiServices.Controllers.Base;

[Route("api/Base")]
public class UserAccountController : BaseController
{
    public UserAccountController(IUserAccount_Service userAccountService)
    {
        this.userAccountService = userAccountService;
    }

    private IUserAccount_Service userAccountService { get; set; }

    [HttpGet]
    [Route("UserAccount/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.userAccountService.RetrieveById(id, UserAccount.Informer, this.UserCredit);

        return result.ToActionResult<UserAccount>();
    }

    [HttpGet]
    [Route("UserAccount/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.userAccountService.RetrieveAll(UserAccount.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<UserAccount>();
    }
            

    
    [HttpPost]
    [Route("UserAccount/Save")]
    public async Task<IActionResult> Save([FromBody] UserAccount userAccount)
    {
        var result = await this.userAccountService.Save(userAccount, this.UserCredit);

        return result.ToActionResult<UserAccount>();
    }

    
    [HttpPost]
    [Route("UserAccount/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] UserAccount userAccount)
    {
        var result = await this.userAccountService.SaveAttached(userAccount, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("UserAccount/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<UserAccount> userAccountList)
    {
        var result = await this.userAccountService.SaveBulk(userAccountList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("UserAccount/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] UserAccount userAccount, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.userAccountService.Seek(userAccount, this.UserCredit, pageNumber);

        return result.ToActionResult<UserAccount>();
    }

    [HttpGet]
    [Route("UserAccount/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.userAccountService.SeekByValue(seekValue, UserAccount.Informer);

        return result.ToActionResult<UserAccount>();
    }

    [HttpDelete]
    [Route("UserAccount/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] UserAccount userAccount)
    {
        var result = await this.userAccountService.Delete(userAccount, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// UserAccount.CollectionOfClient
    [HttpPost]
    [Route("UserAccount/{userAccount_id:int}/Client")]
    public IActionResult CollectionOfClient([FromRoute(Name = "userAccount_id")] int id, [FromBody] Client client)
    {
        return this.userAccountService.CollectionOfClient(id, client, this.UserCredit).ToActionResult();
    }

		//// UserAccount.CollectionOfEmailVerification
    [HttpPost]
    [Route("UserAccount/{userAccount_id:int}/EmailVerification")]
    public IActionResult CollectionOfEmailVerification([FromRoute(Name = "userAccount_id")] int id, [FromBody] EmailVerification emailVerification)
    {
        return this.userAccountService.CollectionOfEmailVerification(id, emailVerification, this.UserCredit).ToActionResult();
    }

		//// UserAccount.CollectionOfProvider
    [HttpPost]
    [Route("UserAccount/{userAccount_id:int}/Provider")]
    public IActionResult CollectionOfProvider([FromRoute(Name = "userAccount_id")] int id, [FromBody] Provider provider)
    {
        return this.userAccountService.CollectionOfProvider(id, provider, this.UserCredit).ToActionResult();
    }

		//// UserAccount.CollectionOfRoleMember
    [HttpPost]
    [Route("UserAccount/{userAccount_id:int}/RoleMember")]
    public IActionResult CollectionOfRoleMember([FromRoute(Name = "userAccount_id")] int id, [FromBody] RoleMember roleMember)
    {
        return this.userAccountService.CollectionOfRoleMember(id, roleMember, this.UserCredit).ToActionResult();
    }

		//// UserAccount.CollectionOfStaff
    [HttpPost]
    [Route("UserAccount/{userAccount_id:int}/Staff")]
    public IActionResult CollectionOfStaff([FromRoute(Name = "userAccount_id")] int id, [FromBody] Staff staff)
    {
        return this.userAccountService.CollectionOfStaff(id, staff, this.UserCredit).ToActionResult();
    }
}
