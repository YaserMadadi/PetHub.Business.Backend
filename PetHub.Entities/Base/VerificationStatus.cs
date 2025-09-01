
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class VerificationStatus : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "VerificationStatus", "Verification Status", "base/verificationstatus");

    #region Constructor
    public VerificationStatus() : this(0)
    {

    }

    public VerificationStatus(int id) : this(id, new byte[0])
    {

    }

    public VerificationStatus(int id, byte[] timeStamp) : base(id, timeStamp, VerificationStatus.Informer)
    {

    }

    protected VerificationStatus(int id, byte[] timeStamp, Info info) : base(id, timeStamp, VerificationStatus.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }
	
	public bool? IsVerified { get; set; }

	#endregion

    #region    List Of ....

	public List<Client> ListOfClient { get; set; } = new();

	public List<EmailVerification> ListOfEmailVerification { get; set; } = new();

	public List<PhoneNumberVerification> ListOfPhoneNumberVerification { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate() &&
				IsVerified.Validate();
    }
}
