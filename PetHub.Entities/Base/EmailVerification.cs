
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class EmailVerification : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "EmailVerification", "Email Verification", "base/emailverification");

    #region Constructor
    public EmailVerification() : this(0)
    {

    }

    public EmailVerification(int id) : this(id, new byte[0])
    {

    }

    public EmailVerification(int id, byte[] timeStamp) : base(id, timeStamp, EmailVerification.Informer)
    {

    }

    protected EmailVerification(int id, byte[] timeStamp, Info info) : base(id, timeStamp, EmailVerification.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public UserAccount UserAccount { get; set; }
	
	public string VerificationCode { get; set; }
	
	public DateTime? GenerateTime { get; set; }
	
	public DateTime? ExpiryDate { get; set; }
	
    public VerificationStatus VerificationStatus { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return UserAccount.Validate() &&
				VerificationCode.Validate() &&
				GenerateTime.Validate() &&
				ExpiryDate.Validate() &&
				VerificationStatus.Validate();
    }
}
