
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Infra.Abstract;
using PetHub.Entities.Infra;
using PetHub.Entities.Admin;

namespace PetHub.ApiServices.Controllers.Infra;

[Route("api/Infra")]
public class EntityController : BaseController
{
    public EntityController(IEntity_Service entityService)
    {
        this.entityService = entityService;
    }

    private IEntity_Service entityService { get; set; }

    [HttpGet]
    [Route("Entity/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.entityService.RetrieveById(id, Entity.Informer, this.UserCredit);

        return result.ToActionResult<Entity>();
    }

    [HttpGet]
    [Route("Entity/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.entityService.RetrieveAll(Entity.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Entity>();
    }
            

    
    [HttpPost]
    [Route("Entity/Save")]
    public async Task<IActionResult> Save([FromBody] Entity entity)
    {
        var result = await this.entityService.Save(entity, this.UserCredit);

        return result.ToActionResult<Entity>();
    }

    
    [HttpPost]
    [Route("Entity/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Entity entity)
    {
        var result = await this.entityService.SaveAttached(entity, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Entity/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Entity> entityList)
    {
        var result = await this.entityService.SaveBulk(entityList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Entity/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Entity entity, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.entityService.Seek(entity, this.UserCredit, pageNumber);

        return result.ToActionResult<Entity>();
    }

    [HttpGet]
    [Route("Entity/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.entityService.SeekByValue(seekValue, Entity.Informer);

        return result.ToActionResult<Entity>();
    }

    [HttpDelete]
    [Route("Entity/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Entity entity)
    {
        var result = await this.entityService.Delete(entity, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Entity.CollectionOfRolePermission
    [HttpPost]
    [Route("Entity/{entity_id:int}/RolePermission")]
    public IActionResult CollectionOfRolePermission([FromRoute(Name = "entity_id")] int id, [FromBody] RolePermission rolePermission)
    {
        return this.entityService.CollectionOfRolePermission(id, rolePermission, this.UserCredit).ToActionResult();
    }

		//// Entity.CollectionOfStaffPermission
    [HttpPost]
    [Route("Entity/{entity_id:int}/StaffPermission")]
    public IActionResult CollectionOfStaffPermission([FromRoute(Name = "entity_id")] int id, [FromBody] StaffPermission staffPermission)
    {
        return this.entityService.CollectionOfStaffPermission(id, staffPermission, this.UserCredit).ToActionResult();
    }
}
