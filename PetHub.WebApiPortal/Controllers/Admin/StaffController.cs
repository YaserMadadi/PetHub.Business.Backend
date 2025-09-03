
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
public class StaffController : BaseController
{
    public StaffController(IStaff_Service staffService)
    {
        this.staffService = staffService;
    }

    private IStaff_Service staffService { get; set; }

    [HttpGet]
    [Route("Staff/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.staffService.RetrieveById(id, Staff.Informer, this.UserCredit);

        return result.ToActionResult<Staff>();
    }

    [HttpGet]
    [Route("Staff/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.staffService.RetrieveAll(Staff.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Staff>();
    }
            

    
    [HttpPost]
    [Route("Staff/Save")]
    public async Task<IActionResult> Save([FromBody] Staff staff)
    {
        var result = await this.staffService.Save(staff, this.UserCredit);

        return result.ToActionResult<Staff>();
    }

    
    [HttpPost]
    [Route("Staff/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Staff staff)
    {
        var result = await this.staffService.SaveAttached(staff, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Staff/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Staff> staffList)
    {
        var result = await this.staffService.SaveBulk(staffList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Staff/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Staff staff, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.staffService.Seek(staff, this.UserCredit, pageNumber);

        return result.ToActionResult<Staff>();
    }

    [HttpGet]
    [Route("Staff/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.staffService.SeekByValue(seekValue, Staff.Informer);

        return result.ToActionResult<Staff>();
    }

    [HttpDelete]
    [Route("Staff/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Staff staff)
    {
        var result = await this.staffService.Delete(staff, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Staff.CollectionOfStaffPermission
    [HttpPost]
    [Route("Staff/{staff_id:int}/StaffPermission")]
    public IActionResult CollectionOfStaffPermission([FromRoute(Name = "staff_id")] int id, [FromBody] StaffPermission staffPermission)
    {
        return this.staffService.CollectionOfStaffPermission(id, staffPermission, this.UserCredit).ToActionResult();
    }
}
