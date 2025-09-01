
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
public class ClientController : BaseController
{
    public ClientController(IClient_Service clientService)
    {
        this.clientService = clientService;
    }

    private IClient_Service clientService { get; set; }

    [HttpGet]
    [Route("Client/RetrieveById/{id:int}")]
    public async Task<IActionResult> RetrieveById(int id)
    {
        var result = await this.clientService.RetrieveById(id, Client.Informer, this.UserCredit);

        return result.ToActionResult<Client>();
    }

    [HttpGet]
    [Route("Client/RetrieveAll/{pid:int}")]
    public async Task<IActionResult> RetrieveAll([FromRoute(Name = "pid")] short currentPage = 1)
    {
        var result = await this.clientService.RetrieveAll(Client.Informer, currentPage, this.UserCredit);

        return result.ToActionResult<Client>();
    }
            

    
    [HttpPost]
    [Route("Client/Save")]
    public async Task<IActionResult> Save([FromBody] Client client)
    {
        var result = await this.clientService.Save(client, this.UserCredit);

        return result.ToActionResult<Client>();
    }

    
    [HttpPost]
    [Route("Client/SaveAttached")]
    public async Task<IActionResult> SaveAttached([FromBody] Client client)
    {
        var result = await this.clientService.SaveAttached(client, this.UserCredit);

        return result.ToActionResult();
    }

    
    [HttpPost]
    [Route("Client/SaveBulk")]
    public async Task<IActionResult> SaveBulk([FromBody] List<Client> clientList)
    {
        var result = await this.clientService.SaveBulk(clientList, this.UserCredit);

        return result.ToActionResult();
    }

    [HttpPost]
    [Route("Client/Seek/{pid:int}")]
    public async Task<IActionResult> Seek([FromBody] Client client, [FromRoute(Name = "pid")] short pageNumber)
    {
        var result = await this.clientService.Seek(client, this.UserCredit, pageNumber);

        return result.ToActionResult<Client>();
    }

    [HttpGet]
    [Route("Client/SeekByValue/{seekValue}")]
    public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
    {
        var result = await this.clientService.SeekByValue(seekValue, Client.Informer);

        return result.ToActionResult<Client>();
    }

    [HttpDelete]
    [Route("Client/Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Client client)
    {
        var result = await this.clientService.Delete(client, id, this.UserCredit);

        return result.ToActionResult();
    }

    //// Client.CollectionOfClientNotification
    [HttpPost]
    [Route("Client/{client_id:int}/ClientNotification")]
    public IActionResult CollectionOfClientNotification([FromRoute(Name = "client_id")] int id, [FromBody] ClientNotification clientNotification)
    {
        return this.clientService.CollectionOfClientNotification(id, clientNotification, this.UserCredit).ToActionResult();
    }

		//// Client.CollectionOfClientReview
    [HttpPost]
    [Route("Client/{client_id:int}/ClientReview")]
    public IActionResult CollectionOfClientReview([FromRoute(Name = "client_id")] int id, [FromBody] ClientReview clientReview)
    {
        return this.clientService.CollectionOfClientReview(id, clientReview, this.UserCredit).ToActionResult();
    }

		//// Client.CollectionOfClientWallet
    [HttpPost]
    [Route("Client/{client_id:int}/ClientWallet")]
    public IActionResult CollectionOfClientWallet([FromRoute(Name = "client_id")] int id, [FromBody] ClientWallet clientWallet)
    {
        return this.clientService.CollectionOfClientWallet(id, clientWallet, this.UserCredit).ToActionResult();
    }

		//// Client.CollectionOfPet
    [HttpPost]
    [Route("Client/{client_id:int}/Pet")]
    public IActionResult CollectionOfPet([FromRoute(Name = "client_id")] int id, [FromBody] Pet pet)
    {
        return this.clientService.CollectionOfPet(id, pet, this.UserCredit).ToActionResult();
    }

		//// Client.CollectionOfPhoneNumberVerification
    [HttpPost]
    [Route("Client/{client_id:int}/PhoneNumberVerification")]
    public IActionResult CollectionOfPhoneNumberVerification([FromRoute(Name = "client_id")] int id, [FromBody] PhoneNumberVerification phoneNumberVerification)
    {
        return this.clientService.CollectionOfPhoneNumberVerification(id, phoneNumberVerification, this.UserCredit).ToActionResult();
    }
}
