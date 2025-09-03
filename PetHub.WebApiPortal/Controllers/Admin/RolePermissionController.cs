
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
public class RolePermissionController : BaseController
{
    public RolePermissionController(IRolePermission_Service rolePermissionService)
    {
        this.rolePermissionService = rolePermissionService;
    }

    private IRolePermission_Service rolePermissionService { get; set; }

    [HttpGet]
    [Route("RolePermission/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.rolePermissionService.RetrieveById(id, RolePermission.Informer, this.UserCredit);

        return result.ToActionResult<RolePermission>();
    }

    [HttpGet]
    [Route("RolePermission/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.rolePermissionService.RetrieveAll(RolePermission.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<RolePermission>();
    }
            

    
    [HttpPost]
    [Route("RolePermission/Save")]
    public async Task<IActionResult> Save([FromBody] RolePermission rolePermission)
    {
        var result = await this.rolePermissionService.Save(rolePermission, this.UserCredit);

        return result.ToActionResult<RolePermission>();
    }

    
    [HttpPost]
    [Route("RolePermission/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] RolePermission rolePermission)
    {
        var result = await this.rolePermissionService.SaveAttached(rolePermission, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("RolePermission/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<RolePermission> rolePermissionList)
    {
        var result = await this.rolePermissionService.SaveBulk(rolePermissionList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("RolePermission/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] RolePermission rolePermission, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.rolePermissionService.Seek(rolePermission, this.UserCredit, pageNumber);

        return result.ToActionResult<RolePermission>();
    }

    [HttpGet]
    [Route("RolePermission/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.rolePermissionService.SeekByValue(seekValue, RolePermission.Informer);

        return result.ToActionResult<RolePermission>();
    }

    [HttpDelete]
    [Route("RolePermission/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] RolePermission rolePermission)
    {
        var result = await this.rolePermissionService.Delete(rolePermission, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
