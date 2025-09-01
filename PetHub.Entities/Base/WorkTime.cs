
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class WorkTime : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "WorkTime", "Work Time", "base/worktime");

    #region Constructor
    public WorkTime() : this(0)
    {

    }

    public WorkTime(int id) : this(id, new byte[0])
    {

    }

    public WorkTime(int id, byte[] timeStamp) : base(id, timeStamp, WorkTime.Informer)
    {

    }

    protected WorkTime(int id, byte[] timeStamp, Info info) : base(id, timeStamp, WorkTime.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Provider { get; set; }
	
    public WeekDay WeekDay { get; set; }
	
    public TimeOnly? From { get; set; }
	
    public TimeOnly? To { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				WeekDay.Validate() &&
				From.Validate() &&
				To.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
