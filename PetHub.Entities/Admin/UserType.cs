
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Admin;

public class UserType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Admin", "UserType", "User Type", "admin/usertype");

    #region Constructor
    public UserType() : this(0)
    {

    }

    public UserType(int id) : this(id, new byte[0])
    {

    }

    public UserType(int id, byte[] timeStamp) : base(id, timeStamp, UserType.Informer)
    {

    }

    protected UserType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, UserType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	public List<Menu> ListOfMenu { get; set; } = new();

	public List<Base.UserAccount> ListOfUserAccount { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate() &&
				Note.Validate();
    }
}
