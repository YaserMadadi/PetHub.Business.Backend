
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class BackgroundCheckStatus : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "BackgroundCheckStatus", "Background Check Status", "base/backgroundcheckstatus");

    #region Constructor
    public BackgroundCheckStatus() : this(0)
    {

    }

    public BackgroundCheckStatus(int id) : this(id, new byte[0])
    {

    }

    public BackgroundCheckStatus(int id, byte[] timeStamp) : base(id, timeStamp, BackgroundCheckStatus.Informer)
    {

    }

    protected BackgroundCheckStatus(int id, byte[] timeStamp, Info info) : base(id, timeStamp, BackgroundCheckStatus.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<IndividualProvider> ListOfIndividualProvider { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
