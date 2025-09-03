
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Admin.Abstract;
using PetHub.Entities.Admin;
using PetHub.Entities.Base;

namespace PetHub.ApiServices.Controllers.Admin;

[Route("api/Admin")]
public class UserTypeController : BaseController
{
    public UserTypeController(IUserType_Service userTypeService)
    {
        this.userTypeService = userTypeService;
    }

    private IUserType_Service userTypeService { get; set; }

    [HttpGet]
    [Route("UserType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.userTypeService.RetrieveById(id, UserType.Informer, this.UserCredit);

        return result.ToActionResult<UserType>();
    }

    [HttpGet]
    [Route("UserType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.userTypeService.RetrieveAll(UserType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<UserType>();
    }
            

    
    [HttpPost]
    [Route("UserType/Save")]
    public async Task<IActionResult> Save([FromBody] UserType userType)
    {
        var result = await this.userTypeService.Save(userType, this.UserCredit);

        return result.ToActionResult<UserType>();
    }

    
    [HttpPost]
    [Route("UserType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] UserType userType)
    {
        var result = await this.userTypeService.SaveAttached(userType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("UserType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<UserType> userTypeList)
    {
        var result = await this.userTypeService.SaveBulk(userTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("UserType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] UserType userType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.userTypeService.Seek(userType, this.UserCredit, pageNumber);

        return result.ToActionResult<UserType>();
    }

    [HttpGet]
    [Route("UserType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.userTypeService.SeekByValue(seekValue, UserType.Informer);

        return result.ToActionResult<UserType>();
    }

    [HttpDelete]
    [Route("UserType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] UserType userType)
    {
        var result = await this.userTypeService.Delete(userType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// UserType.CollectionOfMenu
    [HttpPost]
    [Route("UserType/{userType_id:int}/Menu")]
    public IActionResult CollectionOfMenu([FromRoute(Name = "userType_id")] int id, [FromBody] Menu menu)
    {
        return this.userTypeService.CollectionOfMenu(id, menu, this.UserCredit).ToActionResult();
    }

		//// UserType.CollectionOfUserAccount
    [HttpPost]
    [Route("UserType/{userType_id:int}/UserAccount")]
    public IActionResult CollectionOfUserAccount([FromRoute(Name = "userType_id")] int id, [FromBody] UserAccount userAccount)
    {
        return this.userTypeService.CollectionOfUserAccount(id, userAccount, this.UserCredit).ToActionResult();
    }
}
