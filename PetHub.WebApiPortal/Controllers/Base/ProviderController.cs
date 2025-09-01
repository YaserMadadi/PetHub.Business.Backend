
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
public class ProviderController : BaseController
{
    public ProviderController(IProvider_Service providerService)
    {
        this.providerService = providerService;
    }

    private IProvider_Service providerService { get; set; }

    [HttpGet]
    [Route("Provider/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.providerService.RetrieveById(id, Provider.Informer, this.UserCredit);

        return result.ToActionResult<Provider>();
    }

    [HttpGet]
    [Route("Provider/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.providerService.RetrieveAll(Provider.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Provider>();
    }
            

    
    [HttpPost]
    [Route("Provider/Save")]
    public async Task<IActionResult> Save([FromBody] Provider provider)
    {
        var result = await this.providerService.Save(provider, this.UserCredit);

        return result.ToActionResult<Provider>();
    }

    
    [HttpPost]
    [Route("Provider/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Provider provider)
    {
        var result = await this.providerService.SaveAttached(provider, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Provider/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Provider> providerList)
    {
        var result = await this.providerService.SaveBulk(providerList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Provider/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Provider provider, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.providerService.Seek(provider, this.UserCredit, pageNumber);

        return result.ToActionResult<Provider>();
    }

    [HttpGet]
    [Route("Provider/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.providerService.SeekByValue(seekValue, Provider.Informer);

        return result.ToActionResult<Provider>();
    }

    [HttpDelete]
    [Route("Provider/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Provider provider)
    {
        var result = await this.providerService.Delete(provider, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Provider.CollectionOfAcceptedPetCategory
    [HttpPost]
    [Route("Provider/{provider_id:int}/AcceptedPetCategory")]
    public IActionResult CollectionOfAcceptedPetCategory([FromRoute(Name = "provider_id")] int id, [FromBody] AcceptedPetCategory acceptedPetCategory)
    {
        return this.providerService.CollectionOfAcceptedPetCategory(id, acceptedPetCategory, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfBooking
    [HttpPost]
    [Route("Provider/{provider_id:int}/Booking")]
    public IActionResult CollectionOfBooking([FromRoute(Name = "provider_id")] int id, [FromBody] Booking booking)
    {
        return this.providerService.CollectionOfBooking(id, booking, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfClientReview
    [HttpPost]
    [Route("Provider/{provider_id:int}/ClientReview")]
    public IActionResult CollectionOfClientReview([FromRoute(Name = "provider_id")] int id, [FromBody] ClientReview clientReview)
    {
        return this.providerService.CollectionOfClientReview(id, clientReview, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfLocationCoverage
    [HttpPost]
    [Route("Provider/{provider_id:int}/LocationCoverage")]
    public IActionResult CollectionOfLocationCoverage([FromRoute(Name = "provider_id")] int id, [FromBody] LocationCoverage locationCoverage)
    {
        return this.providerService.CollectionOfLocationCoverage(id, locationCoverage, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderBankAccount
    [HttpPost]
    [Route("Provider/{provider_id:int}/ProviderBankAccount")]
    public IActionResult CollectionOfProviderBankAccount([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderBankAccount providerBankAccount)
    {
        return this.providerService.CollectionOfProviderBankAccount(id, providerBankAccount, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderCertification
    [HttpPost]
    [Route("Provider/{provider_id:int}/ProviderCertification")]
    public IActionResult CollectionOfProviderCertification([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderCertification providerCertification)
    {
        return this.providerService.CollectionOfProviderCertification(id, providerCertification, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderConnection
    [HttpPost]
    [Route("Provider/{provider_id:int}/ProviderConnection")]
    public IActionResult CollectionOfProviderConnection([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderConnection providerConnection)
    {
        return this.providerService.CollectionOfProviderConnection(id, providerConnection, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderPayOut
    [HttpPost]
    [Route("Provider/{provider_id:int}/ProviderPayOut")]
    public IActionResult CollectionOfProviderPayOut([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderPayOut providerPayOut)
    {
        return this.providerService.CollectionOfProviderPayOut(id, providerPayOut, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderService
    [HttpPost]
    [Route("Provider/{provider_id:int}/ProviderService")]
    public IActionResult CollectionOfProviderService([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderService providerService)
    {
        return this.providerService.CollectionOfProviderService(id, providerService, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderWallet
    [HttpPost]
    [Route("Provider/{provider_id:int}/ProviderWallet")]
    public IActionResult CollectionOfProviderWallet([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderWallet providerWallet)
    {
        return this.providerService.CollectionOfProviderWallet(id, providerWallet, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfWorkTime
    [HttpPost]
    [Route("Provider/{provider_id:int}/WorkTime")]
    public IActionResult CollectionOfWorkTime([FromRoute(Name = "provider_id")] int id, [FromBody] WorkTime workTime)
    {
        return this.providerService.CollectionOfWorkTime(id, workTime, this.UserCredit).ToActionResult();
    }
}
