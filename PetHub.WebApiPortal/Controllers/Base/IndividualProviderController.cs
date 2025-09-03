
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
public class IndividualProviderController : BaseController
{
    public IndividualProviderController(IIndividualProvider_Service individualProviderService)
    {
        this.individualProviderService = individualProviderService;
    }

    private IIndividualProvider_Service individualProviderService { get; set; }

    [HttpGet]
    [Route("IndividualProvider/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.individualProviderService.RetrieveById(id, IndividualProvider.Informer, this.UserCredit);

        return result.ToActionResult<IndividualProvider>();
    }

    [HttpGet]
    [Route("IndividualProvider/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.individualProviderService.RetrieveAll(IndividualProvider.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<IndividualProvider>();
    }
            

    
    [HttpPost]
    [Route("IndividualProvider/Save")]
    public async Task<IActionResult> Save([FromBody] IndividualProvider individualProvider)
    {
        var result = await this.individualProviderService.Save(individualProvider, this.UserCredit);

        return result.ToActionResult<IndividualProvider>();
    }

    
    [HttpPost]
    [Route("IndividualProvider/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] IndividualProvider individualProvider)
    {
        var result = await this.individualProviderService.SaveAttached(individualProvider, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("IndividualProvider/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<IndividualProvider> individualProviderList)
    {
        var result = await this.individualProviderService.SaveBulk(individualProviderList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("IndividualProvider/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] IndividualProvider individualProvider, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.individualProviderService.Seek(individualProvider, this.UserCredit, pageNumber);

        return result.ToActionResult<IndividualProvider>();
    }

    [HttpGet]
    [Route("IndividualProvider/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.individualProviderService.SeekByValue(seekValue, IndividualProvider.Informer);

        return result.ToActionResult<IndividualProvider>();
    }

    [HttpDelete]
    [Route("IndividualProvider/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] IndividualProvider individualProvider)
    {
        var result = await this.individualProviderService.Delete(individualProvider, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Provider.CollectionOfAcceptedPetCategory
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/AcceptedPetCategory")]
    public IActionResult CollectionOfAcceptedPetCategory([FromRoute(Name = "provider_id")] int id, [FromBody] AcceptedPetCategory acceptedPetCategory)
    {
        return this.individualProviderService.CollectionOfAcceptedPetCategory(id, acceptedPetCategory, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfBooking
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/Booking")]
    public IActionResult CollectionOfBooking([FromRoute(Name = "provider_id")] int id, [FromBody] Booking booking)
    {
        return this.individualProviderService.CollectionOfBooking(id, booking, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfClientReview
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/ClientReview")]
    public IActionResult CollectionOfClientReview([FromRoute(Name = "provider_id")] int id, [FromBody] ClientReview clientReview)
    {
        return this.individualProviderService.CollectionOfClientReview(id, clientReview, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfLocationCoverage
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/LocationCoverage")]
    public IActionResult CollectionOfLocationCoverage([FromRoute(Name = "provider_id")] int id, [FromBody] LocationCoverage locationCoverage)
    {
        return this.individualProviderService.CollectionOfLocationCoverage(id, locationCoverage, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderBankAccount
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/ProviderBankAccount")]
    public IActionResult CollectionOfProviderBankAccount([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderBankAccount providerBankAccount)
    {
        return this.individualProviderService.CollectionOfProviderBankAccount(id, providerBankAccount, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderCertification
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/ProviderCertification")]
    public IActionResult CollectionOfProviderCertification([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderCertification providerCertification)
    {
        return this.individualProviderService.CollectionOfProviderCertification(id, providerCertification, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderConnection
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/ProviderConnection")]
    public IActionResult CollectionOfProviderConnection([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderConnection providerConnection)
    {
        return this.individualProviderService.CollectionOfProviderConnection(id, providerConnection, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderPayOut
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/ProviderPayOut")]
    public IActionResult CollectionOfProviderPayOut([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderPayOut providerPayOut)
    {
        return this.individualProviderService.CollectionOfProviderPayOut(id, providerPayOut, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderService
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/ProviderService")]
    public IActionResult CollectionOfProviderService([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderService providerService)
    {
        return this.individualProviderService.CollectionOfProviderService(id, providerService, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderWallet
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/ProviderWallet")]
    public IActionResult CollectionOfProviderWallet([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderWallet providerWallet)
    {
        return this.individualProviderService.CollectionOfProviderWallet(id, providerWallet, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfWorkTime
    [HttpPost]
    [Route("IndividualProvider/{provider_id:int}/WorkTime")]
    public IActionResult CollectionOfWorkTime([FromRoute(Name = "provider_id")] int id, [FromBody] WorkTime workTime)
    {
        return this.individualProviderService.CollectionOfWorkTime(id, workTime, this.UserCredit).ToActionResult();
    }
}
