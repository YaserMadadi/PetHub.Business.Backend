
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Gender : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Gender", "Gender", "base/gender");

    #region Constructor
    public Gender() : this(0)
    {

    }

    public Gender(int id) : this(id, new byte[0])
    {

    }

    public Gender(int id, byte[] timeStamp) : base(id, timeStamp, Gender.Informer)
    {

    }

    protected Gender(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Gender.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public string PreFix { get; set; }

	#endregion

    #region    List Of ....

	public List<Client> ListOfClient { get; set; } = new();

	public List<IndividualProvider> ListOfIndividualProvider { get; set; } = new();

	public List<Pet> ListOfPet { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				PreFix.Validate();
    }
}
