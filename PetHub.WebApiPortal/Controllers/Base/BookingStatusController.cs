
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
public class BookingStatusController : BaseController
{
    public BookingStatusController(IBookingStatus_Service bookingStatusService)
    {
        this.bookingStatusService = bookingStatusService;
    }

    private IBookingStatus_Service bookingStatusService { get; set; }

    [HttpGet]
    [Route("BookingStatus/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.bookingStatusService.RetrieveById(id, BookingStatus.Informer, this.UserCredit);

        return result.ToActionResult<BookingStatus>();
    }

    [HttpGet]
    [Route("BookingStatus/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.bookingStatusService.RetrieveAll(BookingStatus.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<BookingStatus>();
    }
            

    
    [HttpPost]
    [Route("BookingStatus/Save")]
    public async Task<IActionResult> Save([FromBody] BookingStatus bookingStatus)
    {
        var result = await this.bookingStatusService.Save(bookingStatus, this.UserCredit);

        return result.ToActionResult<BookingStatus>();
    }

    
    [HttpPost]
    [Route("BookingStatus/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] BookingStatus bookingStatus)
    {
        var result = await this.bookingStatusService.SaveAttached(bookingStatus, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("BookingStatus/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<BookingStatus> bookingStatusList)
    {
        var result = await this.bookingStatusService.SaveBulk(bookingStatusList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("BookingStatus/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] BookingStatus bookingStatus, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.bookingStatusService.Seek(bookingStatus, this.UserCredit, pageNumber);

        return result.ToActionResult<BookingStatus>();
    }

    [HttpGet]
    [Route("BookingStatus/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.bookingStatusService.SeekByValue(seekValue, BookingStatus.Informer);

        return result.ToActionResult<BookingStatus>();
    }

    [HttpDelete]
    [Route("BookingStatus/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BookingStatus bookingStatus)
    {
        var result = await this.bookingStatusService.Delete(bookingStatus, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// BookingStatus.CollectionOfBooking
    [HttpPost]
    [Route("BookingStatus/{bookingStatus_id:int}/Booking")]
    public IActionResult CollectionOfBooking([FromRoute(Name = "bookingStatus_id")] int id, [FromBody] Booking booking)
    {
        return this.bookingStatusService.CollectionOfBooking(id, booking, this.UserCredit).ToActionResult();
    }
}
