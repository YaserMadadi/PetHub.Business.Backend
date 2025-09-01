
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class InsuranceType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "InsuranceType", "Insurance Type", "base/insurancetype");

    #region Constructor
    public InsuranceType() : this(0)
    {

    }

    public InsuranceType(int id) : this(id, new byte[0])
    {

    }

    public InsuranceType(int id, byte[] timeStamp) : base(id, timeStamp, InsuranceType.Informer)
    {

    }

    protected InsuranceType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, InsuranceType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
