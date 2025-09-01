
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Base;

namespace PetHub.ApiServices.Controllers.Base;

[Route("api/Base")] // Test
public class PetController : BaseController
{
    public PetController(IPet_Service petService)
    {
        this.petService = petService;
    }

    private IPet_Service petService { get; set; }

    [HttpGet]
    [Route("Pet/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.petService.RetrieveById(id, Pet.Informer, this.UserCredit);

        return result.ToActionResult<Pet>();
    }

    [HttpGet]
    [Route("Pet/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.petService.RetrieveAll(Pet.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Pet>();
    }
            

    
    [HttpPost]
    [Route("Pet/Save")]
    public async Task<IActionResult> Save([FromBody] Pet pet)
    {
        var result = await this.petService.Save(pet, this.UserCredit);

        return result.ToActionResult<Pet>();
    }

    
    [HttpPost]
    [Route("Pet/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Pet pet)
    {
        var result = await this.petService.SaveAttached(pet, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Pet/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Pet> petList)
    {
        var result = await this.petService.SaveBulk(petList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Pet/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Pet pet, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.petService.Seek(pet, this.UserCredit, pageNumber);

        return result.ToActionResult<Pet>();
    }

    [HttpGet]
    [Route("Pet/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.petService.SeekByValue(seekValue, Pet.Informer);

        return result.ToActionResult<Pet>();
    }

    [HttpDelete]
    [Route("Pet/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Pet pet)
    {
        var result = await this.petService.Delete(pet, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Pet.CollectionOfBooking
    [HttpPost]
    [Route("Pet/{pet_id:int}/Booking")]
    public IActionResult CollectionOfBooking([FromRoute(Name = "pet_id")] int id, [FromBody] Booking booking)
    {
        return this.petService.CollectionOfBooking(id, booking, this.UserCredit).ToActionResult();
    }

		//// Pet.CollectionOfPetBehavior
    [HttpPost]
    [Route("Pet/{pet_id:int}/PetBehavior")]
    public IActionResult CollectionOfPetBehavior([FromRoute(Name = "pet_id")] int id, [FromBody] PetBehavior petBehavior)
    {
        return this.petService.CollectionOfPetBehavior(id, petBehavior, this.UserCredit).ToActionResult();
    }

		//// Pet.CollectionOfPetMedicalCondition
    [HttpPost]
    [Route("Pet/{pet_id:int}/PetMedicalCondition")]
    public IActionResult CollectionOfPetMedicalCondition([FromRoute(Name = "pet_id")] int id, [FromBody] PetMedicalCondition petMedicalCondition)
    {
        return this.petService.CollectionOfPetMedicalCondition(id, petMedicalCondition, this.UserCredit).ToActionResult();
    }
}
