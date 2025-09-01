
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class UserAccount : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "UserAccount", "User Account", "base/useraccount");

    #region Constructor
    public UserAccount() : this(0)
    {

    }

    public UserAccount(int id) : this(id, new byte[0])
    {

    }

    public UserAccount(int id, byte[] timeStamp) : base(id, timeStamp, UserAccount.Informer)
    {

    }

    protected UserAccount(int id, byte[] timeStamp, Info info) : base(id, timeStamp, UserAccount.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Email { get; set; }
	
	public byte[] Password { get; set; }
	
	public byte[] Hash { get; set; }
	
    public AccountStatus AccountStatus { get; set; }
	
	public string StatusNote { get; set; }
	
	public bool? EmailIsVerified { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Client> ListOfClient { get; set; } = new();

	public List<EmailVerification> ListOfEmailVerification { get; set; } = new();

	public List<Provider> ListOfProvider { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Email.Validate() &&
				Password.Validate() &&
				Hash.Validate() &&
				AccountStatus.Validate() &&
				StatusNote.Validate() &&
				EmailIsVerified.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
