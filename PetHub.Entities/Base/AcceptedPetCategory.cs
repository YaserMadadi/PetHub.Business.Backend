
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class AcceptedPetCategory : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "AcceptedPetCategory", "Accepted Pet Category", "base/acceptedpetcategory");

    #region Constructor
    public AcceptedPetCategory() : this(0)
    {

    }

    public AcceptedPetCategory(int id) : this(id, new byte[0])
    {

    }

    public AcceptedPetCategory(int id, byte[] timeStamp) : base(id, timeStamp, AcceptedPetCategory.Informer)
    {

    }

    protected AcceptedPetCategory(int id, byte[] timeStamp, Info info) : base(id, timeStamp, AcceptedPetCategory.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Provider { get; set; }
	
    public PetCategory PetCategory { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				PetCategory.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
