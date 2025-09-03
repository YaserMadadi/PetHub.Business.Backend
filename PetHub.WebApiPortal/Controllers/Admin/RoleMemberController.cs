
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Admin.Abstract;
using PetHub.Entities.Admin;

namespace PetHub.ApiServices.Controllers.Admin;

[Route("api/Admin")]
public class RoleMemberController : BaseController
{
    public RoleMemberController(IRoleMember_Service roleMemberService)
    {
        this.roleMemberService = roleMemberService;
    }

    private IRoleMember_Service roleMemberService { get; set; }

    [HttpGet]
    [Route("RoleMember/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.roleMemberService.RetrieveById(id, RoleMember.Informer, this.UserCredit);

        return result.ToActionResult<RoleMember>();
    }

    [HttpGet]
    [Route("RoleMember/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.roleMemberService.RetrieveAll(RoleMember.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<RoleMember>();
    }
            

    
    [HttpPost]
    [Route("RoleMember/Save")]
    public async Task<IActionResult> Save([FromBody] RoleMember roleMember)
    {
        var result = await this.roleMemberService.Save(roleMember, this.UserCredit);

        return result.ToActionResult<RoleMember>();
    }

    
    [HttpPost]
    [Route("RoleMember/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] RoleMember roleMember)
    {
        var result = await this.roleMemberService.SaveAttached(roleMember, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("RoleMember/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<RoleMember> roleMemberList)
    {
        var result = await this.roleMemberService.SaveBulk(roleMemberList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("RoleMember/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] RoleMember roleMember, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.roleMemberService.Seek(roleMember, this.UserCredit, pageNumber);

        return result.ToActionResult<RoleMember>();
    }

    [HttpGet]
    [Route("RoleMember/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.roleMemberService.SeekByValue(seekValue, RoleMember.Informer);

        return result.ToActionResult<RoleMember>();
    }

    [HttpDelete]
    [Route("RoleMember/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] RoleMember roleMember)
    {
        var result = await this.roleMemberService.Delete(roleMember, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
