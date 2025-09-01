
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Base;

namespace PetHub.ApiServices.Controllers.Base;

[Route("api/Base")]
public class MedicationTypeController : BaseController
{
    public MedicationTypeController(IMedicationType_Service medicationTypeService)
    {
        this.medicationTypeService = medicationTypeService;
    }

    private IMedicationType_Service medicationTypeService { get; set; }

    [HttpGet]
    [Route("MedicationType/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.medicationTypeService.RetrieveById(id, MedicationType.Informer, this.UserCredit);

        return result.ToActionResult<MedicationType>();
    }

    [HttpGet]
    [Route("MedicationType/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.medicationTypeService.RetrieveAll(MedicationType.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<MedicationType>();
    }
            

    
    [HttpPost]
    [Route("MedicationType/Save")]
    public async Task<IActionResult> Save([FromBody] MedicationType medicationType)
    {
        var result = await this.medicationTypeService.Save(medicationType, this.UserCredit);

        return result.ToActionResult<MedicationType>();
    }

    
    [HttpPost]
    [Route("MedicationType/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] MedicationType medicationType)
    {
        var result = await this.medicationTypeService.SaveAttached(medicationType, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("MedicationType/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<MedicationType> medicationTypeList)
    {
        var result = await this.medicationTypeService.SaveBulk(medicationTypeList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("MedicationType/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] MedicationType medicationType, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.medicationTypeService.Seek(medicationType, this.UserCredit, pageNumber);

        return result.ToActionResult<MedicationType>();
    }

    [HttpGet]
    [Route("MedicationType/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.medicationTypeService.SeekByValue(seekValue, MedicationType.Informer);

        return result.ToActionResult<MedicationType>();
    }

    [HttpDelete]
    [Route("MedicationType/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MedicationType medicationType)
    {
        var result = await this.medicationTypeService.Delete(medicationType, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// MedicationType.CollectionOfPetMedicalCondition
    [HttpPost]
    [Route("MedicationType/{medicationType_id:int}/PetMedicalCondition")]
    public IActionResult CollectionOfPetMedicalCondition([FromRoute(Name = "medicationType_id")] int id, [FromBody] PetMedicalCondition petMedicalCondition)
    {
        return this.medicationTypeService.CollectionOfPetMedicalCondition(id, petMedicalCondition, this.UserCredit).ToActionResult();
    }
}
