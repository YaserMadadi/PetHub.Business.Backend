
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;
using PetHub.Entities.Fund;

namespace PetHub.Services.Base.Abstract;

public interface IProvider_Service : IService<Provider>
{
    DataResult<List<AcceptedPetCategory>> CollectionOfAcceptedPetCategory(int acceptedPetCategory_Id, AcceptedPetCategory acceptedPetCategory, UserCredit userCredit);

	DataResult<List<Booking>> CollectionOfBooking(int booking_Id, Booking booking, UserCredit userCredit);

	DataResult<List<ClientReview>> CollectionOfClientReview(int clientReview_Id, ClientReview clientReview, UserCredit userCredit);

	DataResult<List<LocationCoverage>> CollectionOfLocationCoverage(int locationCoverage_Id, LocationCoverage locationCoverage, UserCredit userCredit);

	DataResult<List<ProviderBankAccount>> CollectionOfProviderBankAccount(int providerBankAccount_Id, ProviderBankAccount providerBankAccount, UserCredit userCredit);

	DataResult<List<ProviderCertification>> CollectionOfProviderCertification(int providerCertification_Id, ProviderCertification providerCertification, UserCredit userCredit);

	DataResult<List<ProviderConnection>> CollectionOfProviderConnection(int providerConnection_Id, ProviderConnection providerConnection, UserCredit userCredit);

	DataResult<List<ProviderPayOut>> CollectionOfProviderPayOut(int providerPayOut_Id, ProviderPayOut providerPayOut, UserCredit userCredit);

	DataResult<List<ProviderService>> CollectionOfProviderService(int providerService_Id, ProviderService providerService, UserCredit userCredit);

	DataResult<List<ProviderWallet>> CollectionOfProviderWallet(int providerWallet_Id, ProviderWallet providerWallet, UserCredit userCredit);

	DataResult<List<WorkTime>> CollectionOfWorkTime(int workTime_Id, WorkTime workTime, UserCredit userCredit);
}
