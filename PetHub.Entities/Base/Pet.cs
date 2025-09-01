
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Pet : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Pet", "Pet", "base/pet");

    #region Constructor
    public Pet() : this(0)
    {

    }

    public Pet(int id) : this(id, new byte[0])
    {

    }

    public Pet(int id, byte[] timeStamp) : base(id, timeStamp, Pet.Informer)
    {

    }

    protected Pet(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Pet.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Client Client { get; set; }
	
	public string Name { get; set; }
	
    public Gender Gender { get; set; }
	
	public string Breed { get; set; }
	
    public short? Weight { get; set; }
	
    public WeightUnit WeightUnit { get; set; }
	
	public string Color { get; set; }
	
    public DateOnly? DateOfBirth { get; set; }
	
	public string ProfilePicture { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Booking> ListOfBooking { get; set; } = new();

	public List<PetBehavior> ListOfPetBehavior { get; set; } = new();

	public List<PetMedicalCondition> ListOfPetMedicalCondition { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Client.Validate() &&
				Name.Validate() &&
				Gender.Validate() &&
				Breed.Validate() &&
				Weight.Validate() &&
				WeightUnit.Validate() &&
				Color.Validate() &&
				DateOfBirth.Validate() &&
				ProfilePicture.Validate() &&
				IsActive.Validate();
    }
}
