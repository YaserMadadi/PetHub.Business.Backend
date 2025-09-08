using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Core
{
	public class UserAccount : EntityBase, IEntityBase
	{
		public UserAccount() : base(UserAccount.Informer)
		{


		}

		protected static Info Informer { get; private set; } = new Info("Core", "UserAccount", "User Account");


		public string Email { get; set; }

		public string Password { get; set; }

		public int UserType_Id { get; set; }
	}
}
