
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class PetBehavior : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "PetBehavior", "Pet Behavior", "base/petbehavior");

    #region Constructor
    public PetBehavior() : this(0)
    {

    }

    public PetBehavior(int id) : this(id, new byte[0])
    {

    }

    public PetBehavior(int id, byte[] timeStamp) : base(id, timeStamp, PetBehavior.Informer)
    {

    }

    protected PetBehavior(int id, byte[] timeStamp, Info info) : base(id, timeStamp, PetBehavior.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Pet Pet { get; set; }
	
    public BehaviorCategory BehaviorCategory { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Pet.Validate() &&
				BehaviorCategory.Validate() &&
				Note.Validate();
    }
}
