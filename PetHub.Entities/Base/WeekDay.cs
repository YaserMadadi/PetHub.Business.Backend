
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class WeekDay : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "WeekDay", "Week Day", "base/weekday");

    #region Constructor
    public WeekDay() : this(0)
    {

    }

    public WeekDay(int id) : this(id, new byte[0])
    {

    }

    public WeekDay(int id, byte[] timeStamp) : base(id, timeStamp, WeekDay.Informer)
    {

    }

    protected WeekDay(int id, byte[] timeStamp, Info info) : base(id, timeStamp, WeekDay.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }

	#endregion

    #region    List Of ....

	public List<ServiceOrientedWorkTime> ListOfServiceOrientedWorkTime { get; set; } = new();

	public List<WorkTime> ListOfWorkTime { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate();
    }
}
