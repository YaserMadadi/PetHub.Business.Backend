
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
public class PetMedicalConditionController : BaseController
{
    public PetMedicalConditionController(IPetMedicalCondition_Service petMedicalConditionService)
    {
        this.petMedicalConditionService = petMedicalConditionService;
    }

    private IPetMedicalCondition_Service petMedicalConditionService { get; set; }

    [HttpGet]
    [Route("PetMedicalCondition/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.petMedicalConditionService.RetrieveById(id, PetMedicalCondition.Informer, this.UserCredit);

        return result.ToActionResult<PetMedicalCondition>();
    }

    [HttpGet]
    [Route("PetMedicalCondition/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.petMedicalConditionService.RetrieveAll(PetMedicalCondition.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<PetMedicalCondition>();
    }
            

    
    [HttpPost]
    [Route("PetMedicalCondition/Save")]
    public async Task<IActionResult> Save([FromBody] PetMedicalCondition petMedicalCondition)
    {
        var result = await this.petMedicalConditionService.Save(petMedicalCondition, this.UserCredit);

        return result.ToActionResult<PetMedicalCondition>();
    }

    
    [HttpPost]
    [Route("PetMedicalCondition/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] PetMedicalCondition petMedicalCondition)
    {
        var result = await this.petMedicalConditionService.SaveAttached(petMedicalCondition, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("PetMedicalCondition/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<PetMedicalCondition> petMedicalConditionList)
    {
        var result = await this.petMedicalConditionService.SaveBulk(petMedicalConditionList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("PetMedicalCondition/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] PetMedicalCondition petMedicalCondition, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.petMedicalConditionService.Seek(petMedicalCondition, this.UserCredit, pageNumber);

        return result.ToActionResult<PetMedicalCondition>();
    }

    [HttpGet]
    [Route("PetMedicalCondition/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.petMedicalConditionService.SeekByValue(seekValue, PetMedicalCondition.Informer);

        return result.ToActionResult<PetMedicalCondition>();
    }

    [HttpDelete]
    [Route("PetMedicalCondition/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PetMedicalCondition petMedicalCondition)
    {
        var result = await this.petMedicalConditionService.Delete(petMedicalCondition, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
