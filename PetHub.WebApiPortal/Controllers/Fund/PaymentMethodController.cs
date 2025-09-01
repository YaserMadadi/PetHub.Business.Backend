
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
public class PaymentMethodController : BaseController
{
    public PaymentMethodController(IPaymentMethod_Service paymentMethodService)
    {
        this.paymentMethodService = paymentMethodService;
    }

    private IPaymentMethod_Service paymentMethodService { get; set; }

    [HttpGet]
    [Route("PaymentMethod/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.paymentMethodService.RetrieveById(id, PaymentMethod.Informer, this.UserCredit);

        return result.ToActionResult<PaymentMethod>();
    }

    [HttpGet]
    [Route("PaymentMethod/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.paymentMethodService.RetrieveAll(PaymentMethod.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<PaymentMethod>();
    }
            

    
    [HttpPost]
    [Route("PaymentMethod/Save")]
    public async Task<IActionResult> Save([FromBody] PaymentMethod paymentMethod)
    {
        var result = await this.paymentMethodService.Save(paymentMethod, this.UserCredit);

        return result.ToActionResult<PaymentMethod>();
    }

    
    [HttpPost]
    [Route("PaymentMethod/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] PaymentMethod paymentMethod)
    {
        var result = await this.paymentMethodService.SaveAttached(paymentMethod, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("PaymentMethod/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<PaymentMethod> paymentMethodList)
    {
        var result = await this.paymentMethodService.SaveBulk(paymentMethodList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("PaymentMethod/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] PaymentMethod paymentMethod, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.paymentMethodService.Seek(paymentMethod, this.UserCredit, pageNumber);

        return result.ToActionResult<PaymentMethod>();
    }

    [HttpGet]
    [Route("PaymentMethod/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.paymentMethodService.SeekByValue(seekValue, PaymentMethod.Informer);

        return result.ToActionResult<PaymentMethod>();
    }

    [HttpDelete]
    [Route("PaymentMethod/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PaymentMethod paymentMethod)
    {
        var result = await this.paymentMethodService.Delete(paymentMethod, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// PaymentMethod.CollectionOfWalletTopUp
    [HttpPost]
    [Route("PaymentMethod/{paymentMethod_id:int}/WalletTopUp")]
    public IActionResult CollectionOfWalletTopUp([FromRoute(Name = "paymentMethod_id")] int id, [FromBody] WalletTopUp walletTopUp)
    {
        return this.paymentMethodService.CollectionOfWalletTopUp(id, walletTopUp, this.UserCredit).ToActionResult();
    }
}
