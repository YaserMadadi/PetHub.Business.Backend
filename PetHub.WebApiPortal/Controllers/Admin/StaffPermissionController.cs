
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
public class StaffPermissionController : BaseController
{
    public StaffPermissionController(IStaffPermission_Service staffPermissionService)
    {
        this.staffPermissionService = staffPermissionService;
    }

    private IStaffPermission_Service staffPermissionService { get; set; }

    [HttpGet]
    [Route("StaffPermission/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.staffPermissionService.RetrieveById(id, StaffPermission.Informer, this.UserCredit);

        return result.ToActionResult<StaffPermission>();
    }

    [HttpGet]
    [Route("StaffPermission/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.staffPermissionService.RetrieveAll(StaffPermission.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<StaffPermission>();
    }
            

    
    [HttpPost]
    [Route("StaffPermission/Save")]
    public async Task<IActionResult> Save([FromBody] StaffPermission staffPermission)
    {
        var result = await this.staffPermissionService.Save(staffPermission, this.UserCredit);

        return result.ToActionResult<StaffPermission>();
    }

    
    [HttpPost]
    [Route("StaffPermission/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] StaffPermission staffPermission)
    {
        var result = await this.staffPermissionService.SaveAttached(staffPermission, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("StaffPermission/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<StaffPermission> staffPermissionList)
    {
        var result = await this.staffPermissionService.SaveBulk(staffPermissionList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("StaffPermission/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] StaffPermission staffPermission, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.staffPermissionService.Seek(staffPermission, this.UserCredit, pageNumber);

        return result.ToActionResult<StaffPermission>();
    }

    [HttpGet]
    [Route("StaffPermission/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.staffPermissionService.SeekByValue(seekValue, StaffPermission.Informer);

        return result.ToActionResult<StaffPermission>();
    }

    [HttpDelete]
    [Route("StaffPermission/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] StaffPermission staffPermission)
    {
        var result = await this.staffPermissionService.Delete(staffPermission, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
