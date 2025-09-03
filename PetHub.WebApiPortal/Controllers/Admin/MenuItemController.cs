
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
public class MenuItemController : BaseController
{
    public MenuItemController(IMenuItem_Service menuItemService)
    {
        this.menuItemService = menuItemService;
    }

    private IMenuItem_Service menuItemService { get; set; }

    [HttpGet]
    [Route("MenuItem/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.menuItemService.RetrieveById(id, MenuItem.Informer, this.UserCredit);

        return result.ToActionResult<MenuItem>();
    }

    [HttpGet]
    [Route("MenuItem/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.menuItemService.RetrieveAll(MenuItem.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<MenuItem>();
    }
            

    
    [HttpPost]
    [Route("MenuItem/Save")]
    public async Task<IActionResult> Save([FromBody] MenuItem menuItem)
    {
        var result = await this.menuItemService.Save(menuItem, this.UserCredit);

        return result.ToActionResult<MenuItem>();
    }

    
    [HttpPost]
    [Route("MenuItem/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] MenuItem menuItem)
    {
        var result = await this.menuItemService.SaveAttached(menuItem, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("MenuItem/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<MenuItem> menuItemList)
    {
        var result = await this.menuItemService.SaveBulk(menuItemList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("MenuItem/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] MenuItem menuItem, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.menuItemService.Seek(menuItem, this.UserCredit, pageNumber);

        return result.ToActionResult<MenuItem>();
    }

    [HttpGet]
    [Route("MenuItem/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.menuItemService.SeekByValue(seekValue, MenuItem.Informer);

        return result.ToActionResult<MenuItem>();
    }

    [HttpDelete]
    [Route("MenuItem/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MenuItem menuItem)
    {
        var result = await this.menuItemService.Delete(menuItem, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
