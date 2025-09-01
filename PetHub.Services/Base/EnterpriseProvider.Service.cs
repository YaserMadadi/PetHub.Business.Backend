
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Base;
using PetHub.Services.Base.Actions;
using PetHub.Services.Base.Abstract;
using PetHub.Entities.Fund;

namespace PetHub.Services.Base;

public class EnterpriseProvider_Service : Service<EnterpriseProvider>, IEnterpriseProvider_Service
{
    public EnterpriseProvider_Service() : base()
    {
    }

    public override async Task<DataResult<EnterpriseProvider>> SaveAttached(EnterpriseProvider enterpriseProvider, UserCredit userCredit)
    {
        return await enterpriseProvider.SaveAttached(userCredit);
    }

    public DataResult<List<AcceptedPetCategory>> CollectionOfAcceptedPetCategory(int provider_Id, AcceptedPetCategory acceptedPetCategory, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfAcceptedPetCategory]";

        return this.CollectionOf<AcceptedPetCategory>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", acceptedPetCategory.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<Booking>> CollectionOfBooking(int provider_Id, Booking booking, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfBooking]";

        return this.CollectionOf<Booking>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", booking.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ClientReview>> CollectionOfClientReview(int provider_Id, ClientReview clientReview, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfClientReview]";

        return this.CollectionOf<ClientReview>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", clientReview.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	//public DataResult<EnterpriseProvider> LoadEnterpriseProvider(int enterpriseProvider_Id, EnterpriseProvider enterpriseProvider, UserCredit userCredit)
        //{
        //    var procedureName = "[Base].[EnterpriseProvider.Load]";

            ////  Should be completed...
        //}

		public DataResult<List<EnterpriseProvider>> CollectionOfEnterpriseProvider(int provider_Id, EnterpriseProvider enterpriseProvider, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfEnterpriseProvider]";

        return this.CollectionOf<EnterpriseProvider>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", enterpriseProvider.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	//public DataResult<IndividualProvider> LoadIndividualProvider(int individualProvider_Id, IndividualProvider individualProvider, UserCredit userCredit)
        //{
        //    var procedureName = "[Base].[IndividualProvider.Load]";

            ////  Should be completed...
        //}

		public DataResult<List<IndividualProvider>> CollectionOfIndividualProvider(int provider_Id, IndividualProvider individualProvider, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfIndividualProvider]";

        return this.CollectionOf<IndividualProvider>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", individualProvider.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<LocationCoverage>> CollectionOfLocationCoverage(int provider_Id, LocationCoverage locationCoverage, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfLocationCoverage]";

        return this.CollectionOf<LocationCoverage>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", locationCoverage.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ProviderBankAccount>> CollectionOfProviderBankAccount(int provider_Id, ProviderBankAccount providerBankAccount, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfProviderBankAccount]";

        return this.CollectionOf<ProviderBankAccount>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", providerBankAccount.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ProviderCertification>> CollectionOfProviderCertification(int provider_Id, ProviderCertification providerCertification, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfProviderCertification]";

        return this.CollectionOf<ProviderCertification>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", providerCertification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ProviderConnection>> CollectionOfProviderConnection(int provider_Id, ProviderConnection providerConnection, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfProviderConnection]";

        return this.CollectionOf<ProviderConnection>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", providerConnection.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ProviderPayOut>> CollectionOfProviderPayOut(int provider_Id, ProviderPayOut providerPayOut, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfProviderPayOut]";

        return this.CollectionOf<ProviderPayOut>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", providerPayOut.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ProviderService>> CollectionOfProviderService(int provider_Id, ProviderService providerService, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfProviderService]";

        return this.CollectionOf<ProviderService>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", providerService.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<ProviderWallet>> CollectionOfProviderWallet(int provider_Id, ProviderWallet providerWallet, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfProviderWallet]";

        return this.CollectionOf<ProviderWallet>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", providerWallet.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<WorkTime>> CollectionOfWorkTime(int provider_Id, WorkTime workTime, UserCredit userCredit)
    {
        var procedureName = "[Base].[Provider.CollectionOfWorkTime]";

        return this.CollectionOf<WorkTime>(procedureName, 
                                                        new SqlParameter("@Id", provider_Id), 
                                                        new SqlParameter("@jsonValue", workTime.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }

	public DataResult<List<EnterpriseProviderInsurance>> CollectionOfEnterpriseProviderInsurance(int enterpriseProvider_Id, EnterpriseProviderInsurance enterpriseProviderInsurance, UserCredit userCredit)
    {
        var procedureName = "[Base].[EnterpriseProvider.CollectionOfEnterpriseProviderInsurance]";

        return this.CollectionOf<EnterpriseProviderInsurance>(procedureName, 
                                                        new SqlParameter("@Id", enterpriseProvider_Id), 
                                                        new SqlParameter("@jsonValue", enterpriseProviderInsurance.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
