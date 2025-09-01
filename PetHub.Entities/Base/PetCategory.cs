
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class PetCategory : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "PetCategory", "Pet Category", "base/petcategory");

    #region Constructor
    public PetCategory() : this(0)
    {

    }

    public PetCategory(int id) : this(id, new byte[0])
    {

    }

    public PetCategory(int id, byte[] timeStamp) : base(id, timeStamp, PetCategory.Informer)
    {

    }

    protected PetCategory(int id, byte[] timeStamp, Info info) : base(id, timeStamp, PetCategory.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<AcceptedPetCategory> ListOfAcceptedPetCategory { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
