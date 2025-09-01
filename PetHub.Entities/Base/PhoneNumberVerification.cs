
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class PhoneNumberVerification : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "PhoneNumberVerification", "Phone Number Verification", "base/phonenumberverification");

    #region Constructor
    public PhoneNumberVerification() : this(0)
    {

    }

    public PhoneNumberVerification(int id) : this(id, new byte[0])
    {

    }

    public PhoneNumberVerification(int id, byte[] timeStamp) : base(id, timeStamp, PhoneNumberVerification.Informer)
    {

    }

    protected PhoneNumberVerification(int id, byte[] timeStamp, Info info) : base(id, timeStamp, PhoneNumberVerification.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Client Client { get; set; }
	
	public string VerificationCode { get; set; }
	
	public DateTime? GenerateTime { get; set; }
	
	public DateTime? ExpiryDate { get; set; }
	
    public VerificationStatus VerificationStatus { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Client.Validate() &&
				VerificationCode.Validate() &&
				GenerateTime.Validate() &&
				ExpiryDate.Validate() &&
				VerificationStatus.Validate();
    }
}
