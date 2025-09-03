
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
public class MenuController : BaseController
{
    public MenuController(IMenu_Service menuService)
    {
        this.menuService = menuService;
    }

    private IMenu_Service menuService { get; set; }

    [HttpGet]
    [Route("Menu/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.menuService.RetrieveById(id, Menu.Informer, this.UserCredit);

        return result.ToActionResult<Menu>();
    }

    [HttpGet]
    [Route("Menu/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.menuService.RetrieveAll(Menu.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Menu>();
    }
            

    
    [HttpPost]
    [Route("Menu/Save")]
    public async Task<IActionResult> Save([FromBody] Menu menu)
    {
        var result = await this.menuService.Save(menu, this.UserCredit);

        return result.ToActionResult<Menu>();
    }

    
    [HttpPost]
    [Route("Menu/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Menu menu)
    {
        var result = await this.menuService.SaveAttached(menu, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Menu/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Menu> menuList)
    {
        var result = await this.menuService.SaveBulk(menuList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Menu/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Menu menu, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.menuService.Seek(menu, this.UserCredit, pageNumber);

        return result.ToActionResult<Menu>();
    }

    [HttpGet]
    [Route("Menu/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.menuService.SeekByValue(seekValue, Menu.Informer);

        return result.ToActionResult<Menu>();
    }

    [HttpDelete]
    [Route("Menu/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Menu menu)
    {
        var result = await this.menuService.Delete(menu, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Menu.CollectionOfMenuItem
    [HttpPost]
    [Route("Menu/{menu_id:int}/MenuItem")]
    public IActionResult CollectionOfMenuItem([FromRoute(Name = "menu_id")] int id, [FromBody] MenuItem menuItem)
    {
        return this.menuService.CollectionOfMenuItem(id, menuItem, this.UserCredit).ToActionResult();
    }
}
