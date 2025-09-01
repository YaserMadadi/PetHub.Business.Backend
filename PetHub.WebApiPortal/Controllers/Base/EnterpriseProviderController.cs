
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
public class EnterpriseProviderController : BaseController
{
    public EnterpriseProviderController(IEnterpriseProvider_Service enterpriseProviderService)
    {
        this.enterpriseProviderService = enterpriseProviderService;
    }

    private IEnterpriseProvider_Service enterpriseProviderService { get; set; }

    [HttpGet]
    [Route("EnterpriseProvider/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.enterpriseProviderService.RetrieveById(id, EnterpriseProvider.Informer, this.UserCredit);

        return result.ToActionResult<EnterpriseProvider>();
    }

    [HttpGet]
    [Route("EnterpriseProvider/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.enterpriseProviderService.RetrieveAll(EnterpriseProvider.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<EnterpriseProvider>();
    }
            

    
    [HttpPost]
    [Route("EnterpriseProvider/Save")]
    public async Task<IActionResult> Save([FromBody] EnterpriseProvider enterpriseProvider)
    {
        var result = await this.enterpriseProviderService.Save(enterpriseProvider, this.UserCredit);

        return result.ToActionResult<EnterpriseProvider>();
    }

    
    [HttpPost]
    [Route("EnterpriseProvider/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] EnterpriseProvider enterpriseProvider)
    {
        var result = await this.enterpriseProviderService.SaveAttached(enterpriseProvider, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("EnterpriseProvider/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<EnterpriseProvider> enterpriseProviderList)
    {
        var result = await this.enterpriseProviderService.SaveBulk(enterpriseProviderList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("EnterpriseProvider/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] EnterpriseProvider enterpriseProvider, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.enterpriseProviderService.Seek(enterpriseProvider, this.UserCredit, pageNumber);

        return result.ToActionResult<EnterpriseProvider>();
    }

    [HttpGet]
    [Route("EnterpriseProvider/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.enterpriseProviderService.SeekByValue(seekValue, EnterpriseProvider.Informer);

        return result.ToActionResult<EnterpriseProvider>();
    }

    [HttpDelete]
    [Route("EnterpriseProvider/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EnterpriseProvider enterpriseProvider)
    {
        var result = await this.enterpriseProviderService.Delete(enterpriseProvider, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Provider.CollectionOfAcceptedPetCategory
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/AcceptedPetCategory")]
    public IActionResult CollectionOfAcceptedPetCategory([FromRoute(Name = "provider_id")] int id, [FromBody] AcceptedPetCategory acceptedPetCategory)
    {
        return this.enterpriseProviderService.CollectionOfAcceptedPetCategory(id, acceptedPetCategory, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfBooking
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/Booking")]
    public IActionResult CollectionOfBooking([FromRoute(Name = "provider_id")] int id, [FromBody] Booking booking)
    {
        return this.enterpriseProviderService.CollectionOfBooking(id, booking, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfClientReview
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/ClientReview")]
    public IActionResult CollectionOfClientReview([FromRoute(Name = "provider_id")] int id, [FromBody] ClientReview clientReview)
    {
        return this.enterpriseProviderService.CollectionOfClientReview(id, clientReview, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfLocationCoverage
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/LocationCoverage")]
    public IActionResult CollectionOfLocationCoverage([FromRoute(Name = "provider_id")] int id, [FromBody] LocationCoverage locationCoverage)
    {
        return this.enterpriseProviderService.CollectionOfLocationCoverage(id, locationCoverage, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderBankAccount
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/ProviderBankAccount")]
    public IActionResult CollectionOfProviderBankAccount([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderBankAccount providerBankAccount)
    {
        return this.enterpriseProviderService.CollectionOfProviderBankAccount(id, providerBankAccount, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderCertification
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/ProviderCertification")]
    public IActionResult CollectionOfProviderCertification([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderCertification providerCertification)
    {
        return this.enterpriseProviderService.CollectionOfProviderCertification(id, providerCertification, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderConnection
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/ProviderConnection")]
    public IActionResult CollectionOfProviderConnection([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderConnection providerConnection)
    {
        return this.enterpriseProviderService.CollectionOfProviderConnection(id, providerConnection, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderPayOut
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/ProviderPayOut")]
    public IActionResult CollectionOfProviderPayOut([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderPayOut providerPayOut)
    {
        return this.enterpriseProviderService.CollectionOfProviderPayOut(id, providerPayOut, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderService
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/ProviderService")]
    public IActionResult CollectionOfProviderService([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderService providerService)
    {
        return this.enterpriseProviderService.CollectionOfProviderService(id, providerService, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfProviderWallet
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/ProviderWallet")]
    public IActionResult CollectionOfProviderWallet([FromRoute(Name = "provider_id")] int id, [FromBody] ProviderWallet providerWallet)
    {
        return this.enterpriseProviderService.CollectionOfProviderWallet(id, providerWallet, this.UserCredit).ToActionResult();
    }

		//// Provider.CollectionOfWorkTime
    [HttpPost]
    [Route("EnterpriseProvider/{provider_id:int}/WorkTime")]
    public IActionResult CollectionOfWorkTime([FromRoute(Name = "provider_id")] int id, [FromBody] WorkTime workTime)
    {
        return this.enterpriseProviderService.CollectionOfWorkTime(id, workTime, this.UserCredit).ToActionResult();
    }

		//// EnterpriseProvider.CollectionOfEnterpriseProviderInsurance
    [HttpPost]
    [Route("EnterpriseProvider/{enterpriseProvider_id:int}/EnterpriseProviderInsurance")]
    public IActionResult CollectionOfEnterpriseProviderInsurance([FromRoute(Name = "enterpriseProvider_id")] int id, [FromBody] EnterpriseProviderInsurance enterpriseProviderInsurance)
    {
        return this.enterpriseProviderService.CollectionOfEnterpriseProviderInsurance(id, enterpriseProviderInsurance, this.UserCredit).ToActionResult();
    }
}
