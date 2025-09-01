
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class PetMedicalCondition : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "PetMedicalCondition", "Pet Medical Condition", "base/petmedicalcondition");

    #region Constructor
    public PetMedicalCondition() : this(0)
    {

    }

    public PetMedicalCondition(int id) : this(id, new byte[0])
    {

    }

    public PetMedicalCondition(int id, byte[] timeStamp) : base(id, timeStamp, PetMedicalCondition.Informer)
    {

    }

    protected PetMedicalCondition(int id, byte[] timeStamp, Info info) : base(id, timeStamp, PetMedicalCondition.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Pet Pet { get; set; }
	
    public MedicationType MedicationType { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Pet.Validate() &&
				MedicationType.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
