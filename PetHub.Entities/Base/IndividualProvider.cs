
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class IndividualProvider : Provider, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "IndividualProvider", "Individual Provider", "base/individualprovider");

    #region Constructor
    public IndividualProvider() : this(0)
    {

    }

    public IndividualProvider(int id) : this(id, new byte[0])
    {

    }

    public IndividualProvider(int id, byte[] timeStamp) : base(id, timeStamp, IndividualProvider.Informer)
    {

    }

    protected IndividualProvider(int id, byte[] timeStamp, Info info) : base(id, timeStamp, IndividualProvider.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Id { get; set; }
	
	public string FirstName { get; set; }
	
	public string MiddleName { get; set; }
	
	public string LastName { get; set; }
	
	public string NickName { get; set; }
	
    public Gender Gender { get; set; }
	
    public DateOnly? DateOfBirth { get; set; }
	
    public byte? YearsOfExperience { get; set; }
	
    public BackgroundCheckStatus BackgroundCheckStatus { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return base.Validate() &&
				FirstName.Validate() &&
				MiddleName.Validate() &&
				LastName.Validate() &&
				NickName.Validate() &&
				Gender.Validate() &&
				DateOfBirth.Validate() &&
				YearsOfExperience.Validate() &&
				BackgroundCheckStatus.Validate();
    }
}
