
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Admin;

public class StaffPermission : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Admin", "StaffPermission", "Staff Permission", "admin/staffpermission");

    #region Constructor
    public StaffPermission() : this(0)
    {

    }

    public StaffPermission(int id) : this(id, new byte[0])
    {

    }

    public StaffPermission(int id, byte[] timeStamp) : base(id, timeStamp, StaffPermission.Informer)
    {

    }

    protected StaffPermission(int id, byte[] timeStamp, Info info) : base(id, timeStamp, StaffPermission.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Staff Staff { get; set; }
	
    public Infra.Entity Entity { get; set; }
	
	public bool? AddPermission { get; set; }
	
	public bool? EditPermission { get; set; }
	
	public bool? DeletePermission { get; set; }
	
	public bool? ViewPermission { get; set; }
	
	public bool? IsActive { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Staff.Validate() &&
				Entity.Validate() &&
				AddPermission.Validate() &&
				EditPermission.Validate() &&
				DeletePermission.Validate() &&
				ViewPermission.Validate() &&
				IsActive.Validate() &&
				Note.Validate();
    }
}
