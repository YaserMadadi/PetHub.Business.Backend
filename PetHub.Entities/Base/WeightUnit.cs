
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class WeightUnit : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "WeightUnit", "Weight Unit", "base/weightunit");

    #region Constructor
    public WeightUnit() : this(0)
    {

    }

    public WeightUnit(int id) : this(id, new byte[0])
    {

    }

    public WeightUnit(int id, byte[] timeStamp) : base(id, timeStamp, WeightUnit.Informer)
    {

    }

    protected WeightUnit(int id, byte[] timeStamp, Info info) : base(id, timeStamp, WeightUnit.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Pet> ListOfPet { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
