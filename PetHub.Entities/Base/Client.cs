
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Client : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Client", "Client", "base/client");

    #region Constructor
    public Client() : this(0)
    {

    }

    public Client(int id) : this(id, new byte[0])
    {

    }

    public Client(int id, byte[] timeStamp) : base(id, timeStamp, Client.Informer)
    {

    }

    protected Client(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Client.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string FirstName { get; set; }
	
	public string MiddleName { get; set; }
	
	public string LastName { get; set; }
	
	public string NickName { get; set; }
	
    public Gender Gender { get; set; }
	
    public UserAccount UserAccount { get; set; }
	
	public string PhoneNumber { get; set; }
	
    public VerificationStatus PhoneVerificationStatus { get; set; }
	
    public City City { get; set; }
	
	public string AddressLine { get; set; }
	
	public string ExtendedAddressLine { get; set; }
	
	public string PostalCode { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ClientNotification> ListOfClientNotification { get; set; } = new();

	public List<ClientReview> ListOfClientReview { get; set; } = new();

	public List<Fund.ClientWallet> ListOfClientWallet { get; set; } = new();

	public List<Pet> ListOfPet { get; set; } = new();

	public List<PhoneNumberVerification> ListOfPhoneNumberVerification { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return FirstName.Validate() &&
				MiddleName.Validate() &&
				LastName.Validate() &&
				NickName.Validate() &&
				Gender.Validate() &&
				UserAccount.Validate() &&
				PhoneNumber.Validate() &&
				PhoneVerificationStatus.Validate() &&
				City.Validate() &&
				AddressLine.Validate() &&
				ExtendedAddressLine.Validate() &&
				PostalCode.Validate() &&
				IsActive.Validate();
    }
}
