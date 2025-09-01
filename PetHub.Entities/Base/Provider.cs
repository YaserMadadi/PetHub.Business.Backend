
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Provider : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Provider", "Provider", "base/provider");

    #region Constructor
    public Provider() : this(0)
    {

    }

    public Provider(int id) : this(id, new byte[0])
    {

    }

    public Provider(int id, byte[] timeStamp) : base(id, timeStamp, Provider.Informer)
    {

    }

    protected Provider(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Provider.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public ProviderType ProviderType { get; set; }
	
    public UserAccount UserAccount { get; set; }
	
	public string Name { get; set; }
	
	public string ProfilePicture { get; set; }
	
	public bool? IsVerified { get; set; }
	
    public int? ReviewCount { get; set; }
	
    public decimal? Rate { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<AcceptedPetCategory> ListOfAcceptedPetCategory { get; set; } = new();

	public List<Booking> ListOfBooking { get; set; } = new();

	public List<ClientReview> ListOfClientReview { get; set; } = new();

	public List<EnterpriseProvider> ListOfEnterpriseProvider { get; set; } = new();

	public List<IndividualProvider> ListOfIndividualProvider { get; set; } = new();

	public List<LocationCoverage> ListOfLocationCoverage { get; set; } = new();

	public List<ProviderBankAccount> ListOfProviderBankAccount { get; set; } = new();

	public List<ProviderCertification> ListOfProviderCertification { get; set; } = new();

	public List<ProviderConnection> ListOfProviderConnection { get; set; } = new();

	public List<Fund.ProviderPayOut> ListOfProviderPayOut { get; set; } = new();

	public List<ProviderService> ListOfProviderService { get; set; } = new();

	public List<Fund.ProviderWallet> ListOfProviderWallet { get; set; } = new();

	public List<WorkTime> ListOfWorkTime { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return ProviderType.Validate() &&
				UserAccount.Validate() &&
				Name.Validate() &&
				ProfilePicture.Validate() &&
				IsVerified.Validate() &&
				ReviewCount.Validate() &&
				Rate.Validate() &&
				IsActive.Validate();
    }
}
