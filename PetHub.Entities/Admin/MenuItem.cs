
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Admin;

public class MenuItem : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Admin", "MenuItem", "Menu Item", "admin/menuitem");

    #region Constructor
    public MenuItem() : this(0)
    {

    }

    public MenuItem(int id) : this(id, new byte[0])
    {

    }

    public MenuItem(int id, byte[] timeStamp) : base(id, timeStamp, MenuItem.Informer)
    {

    }

    protected MenuItem(int id, byte[] timeStamp, Info info) : base(id, timeStamp, MenuItem.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public string Icon { get; set; }
	
	public string Url { get; set; }
	
    public Menu Menu { get; set; }
	
	public bool? IsActive { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				Icon.Validate() &&
				Url.Validate() &&
				Menu.Validate() &&
				IsActive.Validate() &&
				Note.Validate();
    }
}
