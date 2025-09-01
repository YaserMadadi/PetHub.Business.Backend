
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class AccountStatus : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "AccountStatus", "Account Status", "base/accountstatus");

    #region Constructor
    public AccountStatus() : this(0)
    {

    }

    public AccountStatus(int id) : this(id, new byte[0])
    {

    }

    public AccountStatus(int id, byte[] timeStamp) : base(id, timeStamp, AccountStatus.Informer)
    {

    }

    protected AccountStatus(int id, byte[] timeStamp, Info info) : base(id, timeStamp, AccountStatus.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<UserAccount> ListOfUserAccount { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
