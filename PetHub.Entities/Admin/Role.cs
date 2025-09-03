
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Admin;

public class Role : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Admin", "Role", "Role", "admin/role");

    #region Constructor
    public Role() : this(0)
    {

    }

    public Role(int id) : this(id, new byte[0])
    {

    }

    public Role(int id, byte[] timeStamp) : base(id, timeStamp, Role.Informer)
    {

    }

    protected Role(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Role.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	public List<RoleMember> ListOfRoleMember { get; set; } = new();

	public List<RolePermission> ListOfRolePermission { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate() &&
				Note.Validate();
    }
}
