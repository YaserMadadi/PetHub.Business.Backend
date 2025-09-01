
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Infra;

public class RecordLog : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Infra", "RecordLog", "Record Log", "infra/recordlog");

    #region Constructor
    public RecordLog() : this(0)
    {

    }

    public RecordLog(int id) : this(id, new byte[0])
    {

    }

    public RecordLog(int id, byte[] timeStamp) : base(id, timeStamp, RecordLog.Informer)
    {

    }

    protected RecordLog(int id, byte[] timeStamp, Info info) : base(id, timeStamp, RecordLog.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string EntityName { get; set; }
	
    public int? RecordID { get; set; }
	
    public int? User_Id { get; set; }
	
	public DateTime? EffectDate { get; set; }
	
	public string OldValue { get; set; }
	
	public string NewValue { get; set; }
	
	public string ActionMode { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return EntityName.Validate() &&
				RecordID.Validate() &&
				User_Id.Validate() &&
				EffectDate.Validate() &&
				OldValue.Validate() &&
				NewValue.Validate() &&
				ActionMode.Validate();
    }
}
