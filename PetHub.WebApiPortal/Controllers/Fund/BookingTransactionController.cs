
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using PetHub.Services.Fund.Abstract;
using PetHub.Entities.Fund;

namespace PetHub.ApiServices.Controllers.Fund;

[Route("api/Fund")]
public class BookingTransactionController : BaseController
{
    public BookingTransactionController(IBookingTransaction_Service bookingTransactionService)
    {
        this.bookingTransactionService = bookingTransactionService;
    }

    private IBookingTransaction_Service bookingTransactionService { get; set; }

    [HttpGet]
    [Route("BookingTransaction/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.bookingTransactionService.RetrieveById(id, BookingTransaction.Informer, this.UserCredit);

        return result.ToActionResult<BookingTransaction>();
    }

    [HttpGet]
    [Route("BookingTransaction/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.bookingTransactionService.RetrieveAll(BookingTransaction.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<BookingTransaction>();
    }
            

    
    [HttpPost]
    [Route("BookingTransaction/Save")]
    public async Task<IActionResult> Save([FromBody] BookingTransaction bookingTransaction)
    {
        var result = await this.bookingTransactionService.Save(bookingTransaction, this.UserCredit);

        return result.ToActionResult<BookingTransaction>();
    }

    
    [HttpPost]
    [Route("BookingTransaction/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] BookingTransaction bookingTransaction)
    {
        var result = await this.bookingTransactionService.SaveAttached(bookingTransaction, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("BookingTransaction/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<BookingTransaction> bookingTransactionList)
    {
        var result = await this.bookingTransactionService.SaveBulk(bookingTransactionList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("BookingTransaction/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] BookingTransaction bookingTransaction, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.bookingTransactionService.Seek(bookingTransaction, this.UserCredit, pageNumber);

        return result.ToActionResult<BookingTransaction>();
    }

    [HttpGet]
    [Route("BookingTransaction/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.bookingTransactionService.SeekByValue(seekValue, BookingTransaction.Informer);

        return result.ToActionResult<BookingTransaction>();
    }

    [HttpDelete]
    [Route("BookingTransaction/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BookingTransaction bookingTransaction)
    {
        var result = await this.bookingTransactionService.Delete(bookingTransaction, id, this.UserCredit);

        return result.ToActionResult();
    }

    
}
