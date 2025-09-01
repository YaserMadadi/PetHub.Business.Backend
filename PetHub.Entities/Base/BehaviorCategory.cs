
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class BehaviorCategory : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "BehaviorCategory", "Behavior Category", "base/behaviorcategory");

    #region Constructor
    public BehaviorCategory() : this(0)
    {

    }

    public BehaviorCategory(int id) : this(id, new byte[0])
    {

    }

    public BehaviorCategory(int id, byte[] timeStamp) : base(id, timeStamp, BehaviorCategory.Informer)
    {

    }

    protected BehaviorCategory(int id, byte[] timeStamp, Info info) : base(id, timeStamp, BehaviorCategory.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<PetBehavior> ListOfPetBehavior { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
