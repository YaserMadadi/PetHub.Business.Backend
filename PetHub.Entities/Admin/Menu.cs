
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Admin;

public class Menu : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Admin", "Menu", "Menu", "admin/menu");

    #region Constructor
    public Menu() : this(0)
    {

    }

    public Menu(int id) : this(id, new byte[0])
    {

    }

    public Menu(int id, byte[] timeStamp) : base(id, timeStamp, Menu.Informer)
    {

    }

    protected Menu(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Menu.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public UserType UserType { get; set; }
	
	public string Title { get; set; }
	
	public string Icon { get; set; }
	
	public bool? IsActive { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	public List<MenuItem> ListOfMenuItem { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return UserType.Validate() &&
				Title.Validate() &&
				Icon.Validate() &&
				IsActive.Validate() &&
				Note.Validate();
    }
}
