
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
public class BookingServiceController : BaseController
{
    public BookingServiceController(IBookingService_Service bookingServiceService)
    {
        this.bookingServiceService = bookingServiceService;
    }

    private IBookingService_Service bookingServiceService { get; set; }

    [HttpGet]
    [Route("BookingService/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.bookingServiceService.RetrieveById(id, BookingService.Informer, this.UserCredit);

        return result.ToActionResult<BookingService>();
    }

    [HttpGet]
    [Route("BookingService/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.bookingServiceService.RetrieveAll(BookingService.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<BookingService>();
    }
            

    
    [HttpPost]
    [Route("BookingService/Save")]
    public async Task<IActionResult> Save([FromBody] BookingService bookingService)
    {
        var result = await this.bookingServiceService.Save(bookingService, this.UserCredit);

        return result.ToActionResult<BookingService>();
    }

    
    [HttpPost]
    [Route("BookingService/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] BookingService bookingService)
    {
        var result = await this.bookingServiceService.SaveAttached(bookingService, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("BookingService/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<BookingService> bookingServiceList)
    {
        var result = await this.bookingServiceService.SaveBulk(bookingServiceList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("BookingService/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] BookingService bookingService, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.bookingServiceService.Seek(bookingService, this.UserCredit, pageNumber);

        return result.ToActionResult<BookingService>();
    }

    [HttpGet]
    [Route("BookingService/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.bookingServiceService.SeekByValue(seekValue, BookingService.Informer);

        return result.ToActionResult<BookingService>();
    }

    [HttpDelete]
    [Route("BookingService/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BookingService bookingService)
    {
        var result = await this.bookingServiceService.Delete(bookingService, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
