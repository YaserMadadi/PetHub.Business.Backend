using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Core
{
    public class RoleMember : EntityBase, IEntityBase
    {
        public RoleMember() : base(RoleMember.Informer)
        {


        }

        internal static Info Informer { get; private set; } = new Info("Core", "RoleMember", "Role Member");

        public Role Role { get; set; }


        public int Employee_Id { get; set; }

        public UserAccount UserAccount { get; set; }

        public bool IsActive { get; set; }
    }
}
