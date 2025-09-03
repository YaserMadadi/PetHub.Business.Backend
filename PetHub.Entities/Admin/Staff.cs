
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Admin;

public class Staff : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Admin", "Staff", "Staff", "admin/staff");

    #region Constructor
    public Staff() : this(0)
    {

    }

    public Staff(int id) : this(id, new byte[0])
    {

    }

    public Staff(int id, byte[] timeStamp) : base(id, timeStamp, Staff.Informer)
    {

    }

    protected Staff(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Staff.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string FirstName { get; set; }
	
	public string MiddleName { get; set; }
	
	public string LastName { get; set; }
	
	public string NickName { get; set; }
	
    public Base.Gender Gender { get; set; }
	
    public Base.UserAccount UserAccount { get; set; }
	
	public string PhoneNumber { get; set; }
	
	public bool? IsActive { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	public List<StaffPermission> ListOfStaffPermission { get; set; } = new();

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
				IsActive.Validate() &&
				Note.Validate();
    }
}
