
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Admin;

public class RoleMember : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Admin", "RoleMember", "Role Member", "admin/rolemember");

    #region Constructor
    public RoleMember() : this(0)
    {

    }

    public RoleMember(int id) : this(id, new byte[0])
    {

    }

    public RoleMember(int id, byte[] timeStamp) : base(id, timeStamp, RoleMember.Informer)
    {

    }

    protected RoleMember(int id, byte[] timeStamp, Info info) : base(id, timeStamp, RoleMember.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Role Role { get; set; }
	
    public Base.UserAccount UserAccount { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Role.Validate() &&
				UserAccount.Validate() &&
				IsActive.Validate();
    }
}
