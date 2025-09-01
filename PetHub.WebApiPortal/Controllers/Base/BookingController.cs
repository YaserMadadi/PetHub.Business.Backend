
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Base;
using PetHub.Entities.Fund;

namespace PetHub.ApiServices.Controllers.Base;

[Route("api/Base")]
public class BookingController : BaseController
{
    public BookingController(IBooking_Service bookingService)
    {
        this.bookingService = bookingService;
    }

    private IBooking_Service bookingService { get; set; }

    [HttpGet]
    [Route("Booking/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.bookingService.RetrieveById(id, Booking.Informer, this.UserCredit);

        return result.ToActionResult<Booking>();
    }

    [HttpGet]
    [Route("Booking/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.bookingService.RetrieveAll(Booking.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Booking>();
    }
            

    
    [HttpPost]
    [Route("Booking/Save")]
    public async Task<IActionResult> Save([FromBody] Booking booking)
    {
        var result = await this.bookingService.Save(booking, this.UserCredit);

        return result.ToActionResult<Booking>();
    }

    
    [HttpPost]
    [Route("Booking/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Booking booking)
    {
        var result = await this.bookingService.SaveAttached(booking, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Booking/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Booking> bookingList)
    {
        var result = await this.bookingService.SaveBulk(bookingList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Booking/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Booking booking, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.bookingService.Seek(booking, this.UserCredit, pageNumber);

        return result.ToActionResult<Booking>();
    }

    [HttpGet]
    [Route("Booking/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.bookingService.SeekByValue(seekValue, Booking.Informer);

        return result.ToActionResult<Booking>();
    }

    [HttpDelete]
    [Route("Booking/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Booking booking)
    {
        var result = await this.bookingService.Delete(booking, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Booking.CollectionOfBookingService
    [HttpPost]
    [Route("Booking/{booking_id:int}/BookingService")]
    public IActionResult CollectionOfBookingService([FromRoute(Name = "booking_id")] int id, [FromBody] BookingService bookingService)
    {
        return this.bookingService.CollectionOfBookingService(id, bookingService, this.UserCredit).ToActionResult();
    }

		//// Booking.CollectionOfBookingTransaction
    [HttpPost]
    [Route("Booking/{booking_id:int}/BookingTransaction")]
    public IActionResult CollectionOfBookingTransaction([FromRoute(Name = "booking_id")] int id, [FromBody] BookingTransaction bookingTransaction)
    {
        return this.bookingService.CollectionOfBookingTransaction(id, bookingTransaction, this.UserCredit).ToActionResult();
    }
}
