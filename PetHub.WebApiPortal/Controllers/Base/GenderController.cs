
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
public class GenderController : BaseController
{
    public GenderController(IGender_Service genderService)
    {
        this.genderService = genderService;
    }

    private IGender_Service genderService { get; set; }

    [HttpGet]
    [Route("Gender/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.genderService.RetrieveById(id, Gender.Informer, this.UserCredit);

        return result.ToActionResult<Gender>();
    }

    [HttpGet]
    [Route("Gender/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.genderService.RetrieveAll(Gender.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Gender>();
    }
            

    
    [HttpPost]
    [Route("Gender/Save")]
    public async Task<IActionResult> Save([FromBody] Gender gender)
    {
        var result = await this.genderService.Save(gender, this.UserCredit);

        return result.ToActionResult<Gender>();
    }

    
    [HttpPost]
    [Route("Gender/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Gender gender)
    {
        var result = await this.genderService.SaveAttached(gender, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Gender/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Gender> genderList)
    {
        var result = await this.genderService.SaveBulk(genderList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Gender/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Gender gender, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.genderService.Seek(gender, this.UserCredit, pageNumber);

        return result.ToActionResult<Gender>();
    }

    [HttpGet]
    [Route("Gender/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.genderService.SeekByValue(seekValue, Gender.Informer);

        return result.ToActionResult<Gender>();
    }

    [HttpDelete]
    [Route("Gender/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Gender gender)
    {
        var result = await this.genderService.Delete(gender, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Gender.CollectionOfClient
    [HttpPost]
    [Route("Gender/{gender_id:int}/Client")]
    public IActionResult CollectionOfClient([FromRoute(Name = "gender_id")] int id, [FromBody] Client client)
    {
        return this.genderService.CollectionOfClient(id, client, this.UserCredit).ToActionResult();
    }

		//// Gender.CollectionOfPet
    [HttpPost]
    [Route("Gender/{gender_id:int}/Pet")]
    public IActionResult CollectionOfPet([FromRoute(Name = "gender_id")] int id, [FromBody] Pet pet)
    {
        return this.genderService.CollectionOfPet(id, pet, this.UserCredit).ToActionResult();
    }

		//// Gender.CollectionOfStaff
    [HttpPost]
    [Route("Gender/{gender_id:int}/Staff")]
    public IActionResult CollectionOfStaff([FromRoute(Name = "gender_id")] int id, [FromBody] Staff staff)
    {
        return this.genderService.CollectionOfStaff(id, staff, this.UserCredit).ToActionResult();
    }
}
