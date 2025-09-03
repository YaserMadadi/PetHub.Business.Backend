
using Microsoft.Extensions.DependencyInjection;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Security.JWT;
using EssentialCore.Tools.Security.Service;
using PetHub.Services.Admin.Abstract;
using PetHub.Services.Admin;
using PetHub.Services.Base.Abstract;
using PetHub.Services.Base;
using PetHub.Services.Fund.Abstract;
using PetHub.Services.Fund;
using PetHub.Services.Infra.Abstract;
using PetHub.Services.Infra;
using PetHub.Services.Extended.Admin.Abstract;
using PetHub.Services.Extended.Admin;


namespace PetHub.Services;

public static class ServiceProvider
{
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenHelper, TokenHelper>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IUserClass, UserClass>();

        

		#region Admin

		// Admin Services
		services.AddScoped<Admin.Abstract.IMenu_Service, Admin.Menu_Service>();
		services.AddScoped<Admin.Abstract.IMenuItem_Service, Admin.MenuItem_Service>();
		services.AddScoped<Admin.Abstract.IRole_Service, Admin.Role_Service>();
		services.AddScoped<Admin.Abstract.IRoleMember_Service, Admin.RoleMember_Service>();
		services.AddScoped<Admin.Abstract.IRolePermission_Service, Admin.RolePermission_Service>();
		services.AddScoped<Admin.Abstract.IStaff_Service, Admin.Staff_Service>();
		services.AddScoped<Admin.Abstract.IStaffPermission_Service, Admin.StaffPermission_Service>();
		services.AddScoped<Admin.Abstract.IUserType_Service, Admin.UserType_Service>();

	
        #endregion

        #region AdminExtended
		//services.AddScoped<I_Service, _Service>();
		#endregion

		#region Base

		// Base Services
		services.AddScoped<Base.Abstract.IAcceptedPetCategory_Service, Base.AcceptedPetCategory_Service>();
		services.AddScoped<Base.Abstract.IAccountStatus_Service, Base.AccountStatus_Service>();
		services.AddScoped<Base.Abstract.IBackgroundCheckStatus_Service, Base.BackgroundCheckStatus_Service>();
		services.AddScoped<Base.Abstract.IBank_Service, Base.Bank_Service>();
		services.AddScoped<Base.Abstract.IBehaviorCategory_Service, Base.BehaviorCategory_Service>();
		services.AddScoped<Base.Abstract.IBooking_Service, Base.Booking_Service>();
		services.AddScoped<Base.Abstract.IBookingService_Service, Base.BookingService_Service>();
		services.AddScoped<Base.Abstract.IBookingStatus_Service, Base.BookingStatus_Service>();
		services.AddScoped<Base.Abstract.ICertification_Service, Base.Certification_Service>();
		services.AddScoped<Base.Abstract.ICertificationType_Service, Base.CertificationType_Service>();
		services.AddScoped<Base.Abstract.ICertIssuingOrganization_Service, Base.CertIssuingOrganization_Service>();
		services.AddScoped<Base.Abstract.ICity_Service, Base.City_Service>();
		services.AddScoped<Base.Abstract.IClient_Service, Base.Client_Service>();
		services.AddScoped<Base.Abstract.IClientNotification_Service, Base.ClientNotification_Service>();
		services.AddScoped<Base.Abstract.IClientReview_Service, Base.ClientReview_Service>();
		services.AddScoped<Base.Abstract.IConnectionType_Service, Base.ConnectionType_Service>();
		services.AddScoped<Base.Abstract.ICountry_Service, Base.Country_Service>();
		services.AddScoped<Base.Abstract.IDurationUnit_Service, Base.DurationUnit_Service>();
		services.AddScoped<Base.Abstract.IEmailVerification_Service, Base.EmailVerification_Service>();
		services.AddScoped<Base.Abstract.IEnterpriseProvider_Service, Base.EnterpriseProvider_Service>();
		services.AddScoped<Base.Abstract.IEnterpriseProviderInsurance_Service, Base.EnterpriseProviderInsurance_Service>();
		services.AddScoped<Base.Abstract.IGender_Service, Base.Gender_Service>();
		services.AddScoped<Base.Abstract.IIndividualProvider_Service, Base.IndividualProvider_Service>();
		services.AddScoped<Base.Abstract.IInsuranceType_Service, Base.InsuranceType_Service>();
		services.AddScoped<Base.Abstract.ILocationCoverage_Service, Base.LocationCoverage_Service>();
		services.AddScoped<Base.Abstract.IMedicationType_Service, Base.MedicationType_Service>();
		services.AddScoped<Base.Abstract.INotificationType_Service, Base.NotificationType_Service>();
		services.AddScoped<Base.Abstract.IPet_Service, Base.Pet_Service>();
		services.AddScoped<Base.Abstract.IPetBehavior_Service, Base.PetBehavior_Service>();
		services.AddScoped<Base.Abstract.IPetCategory_Service, Base.PetCategory_Service>();
		services.AddScoped<Base.Abstract.IPetMedicalCondition_Service, Base.PetMedicalCondition_Service>();
		services.AddScoped<Base.Abstract.IPhoneNumberVerification_Service, Base.PhoneNumberVerification_Service>();
		services.AddScoped<Base.Abstract.IPriceScope_Service, Base.PriceScope_Service>();
		services.AddScoped<Base.Abstract.IProvider_Service, Base.Provider_Service>();
		services.AddScoped<Base.Abstract.IProviderBankAccount_Service, Base.ProviderBankAccount_Service>();
		services.AddScoped<Base.Abstract.IProviderCertification_Service, Base.ProviderCertification_Service>();
		services.AddScoped<Base.Abstract.IProviderConnection_Service, Base.ProviderConnection_Service>();
		services.AddScoped<Base.Abstract.IProviderService_Service, Base.ProviderService_Service>();
		services.AddScoped<Base.Abstract.IProviderType_Service, Base.ProviderType_Service>();
		services.AddScoped<Base.Abstract.IProvince_Service, Base.Province_Service>();
		services.AddScoped<Base.Abstract.IServiceOrientedWorkTime_Service, Base.ServiceOrientedWorkTime_Service>();
		services.AddScoped<Base.Abstract.IServicePrice_Service, Base.ServicePrice_Service>();
		services.AddScoped<Base.Abstract.IServiceType_Service, Base.ServiceType_Service>();
		services.AddScoped<Base.Abstract.IUserAccount_Service, Base.UserAccount_Service>();
		services.AddScoped<Base.Abstract.IVerificationStatus_Service, Base.VerificationStatus_Service>();
		services.AddScoped<Base.Abstract.IWeekDay_Service, Base.WeekDay_Service>();
		services.AddScoped<Base.Abstract.IWeightUnit_Service, Base.WeightUnit_Service>();
		services.AddScoped<Base.Abstract.IWorkTime_Service, Base.WorkTime_Service>();


		#endregion

		#region AdminExtended
		//services.AddScoped<I_Service, _Service>();
		services.AddScoped<IMenu_ExtendedService, Menu_ExtendedService>();
		#endregion

		#region Fund

		// Fund Services
		services.AddScoped<Fund.Abstract.IBookingTransaction_Service, Fund.BookingTransaction_Service>();
		services.AddScoped<Fund.Abstract.IClientWallet_Service, Fund.ClientWallet_Service>();
		services.AddScoped<Fund.Abstract.IClientWalletTransactionLog_Service, Fund.ClientWalletTransactionLog_Service>();
		services.AddScoped<Fund.Abstract.IPaymentMethod_Service, Fund.PaymentMethod_Service>();
		services.AddScoped<Fund.Abstract.IProviderPayOut_Service, Fund.ProviderPayOut_Service>();
		services.AddScoped<Fund.Abstract.IProviderWallet_Service, Fund.ProviderWallet_Service>();
		services.AddScoped<Fund.Abstract.ITransactionStatus_Service, Fund.TransactionStatus_Service>();
		services.AddScoped<Fund.Abstract.ITransactionType_Service, Fund.TransactionType_Service>();
		services.AddScoped<Fund.Abstract.IWalletTopUp_Service, Fund.WalletTopUp_Service>();

	
        #endregion

        #region AdminExtended
		//services.AddScoped<I_Service, _Service>();
		#endregion

		#region Infra

		// Infra Services
		services.AddScoped<Infra.Abstract.ICheckConstraint_Service, Infra.CheckConstraint_Service>();
		services.AddScoped<Infra.Abstract.IEntity_Service, Infra.Entity_Service>();
		services.AddScoped<Infra.Abstract.IExceptionBackend_Service, Infra.ExceptionBackend_Service>();
		services.AddScoped<Infra.Abstract.IExceptionProcedure_Service, Infra.ExceptionProcedure_Service>();
		services.AddScoped<Infra.Abstract.IMessageType_Service, Infra.MessageType_Service>();
		services.AddScoped<Infra.Abstract.IRecordLog_Service, Infra.RecordLog_Service>();
		services.AddScoped<Infra.Abstract.IResultMessage_Service, Infra.ResultMessage_Service>();

	
        #endregion

        #region AdminExtended
		//services.AddScoped<I_Service, _Service>();
		#endregion

    }
}
