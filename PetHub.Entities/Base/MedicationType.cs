
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class MedicationType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "MedicationType", "Medication Type", "base/medicationtype");

    #region Constructor
    public MedicationType() : this(0)
    {

    }

    public MedicationType(int id) : this(id, new byte[0])
    {

    }

    public MedicationType(int id, byte[] timeStamp) : base(id, timeStamp, MedicationType.Informer)
    {

    }

    protected MedicationType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, MedicationType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<PetMedicalCondition> ListOfPetMedicalCondition { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
