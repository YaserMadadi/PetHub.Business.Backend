
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
public class ClientReviewController : BaseController
{
    public ClientReviewController(IClientReview_Service clientReviewService)
    {
        this.clientReviewService = clientReviewService;
    }

    private IClientReview_Service clientReviewService { get; set; }

    [HttpGet]
    [Route("ClientReview/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.clientReviewService.RetrieveById(id, ClientReview.Informer, this.UserCredit);

        return result.ToActionResult<ClientReview>();
    }

    [HttpGet]
    [Route("ClientReview/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.clientReviewService.RetrieveAll(ClientReview.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<ClientReview>();
    }
            

    
    [HttpPost]
    [Route("ClientReview/Save")]
    public async Task<IActionResult> Save([FromBody] ClientReview clientReview)
    {
        var result = await this.clientReviewService.Save(clientReview, this.UserCredit);

        return result.ToActionResult<ClientReview>();
    }

    
    [HttpPost]
    [Route("ClientReview/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] ClientReview clientReview)
    {
        var result = await this.clientReviewService.SaveAttached(clientReview, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("ClientReview/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<ClientReview> clientReviewList)
    {
        var result = await this.clientReviewService.SaveBulk(clientReviewList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("ClientReview/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] ClientReview clientReview, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.clientReviewService.Seek(clientReview, this.UserCredit, pageNumber);

        return result.ToActionResult<ClientReview>();
    }

    [HttpGet]
    [Route("ClientReview/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.clientReviewService.SeekByValue(seekValue, ClientReview.Informer);

        return result.ToActionResult<ClientReview>();
    }

    [HttpDelete]
    [Route("ClientReview/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ClientReview clientReview)
    {
        var result = await this.clientReviewService.Delete(clientReview, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
