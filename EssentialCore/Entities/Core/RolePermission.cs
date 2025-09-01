using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Core
{
    public class RolePermission : EntityBase, IEntityBase
    {
        public RolePermission() : base(Informer)
        {

        } 

        internal static Info Informer { get; private set; } = new Info("Core", "RolePermission", "RolePermission");

        public Role Role { get; set; }

        public Entity Entity { get; set; }

        public bool AddPermission { get; set; }

        public bool EditPermission { get; set; }

        public bool DeletePermission { get; set; }

        public bool ViewIndexPermission { get; set; }

        public bool ViewLogPermission { get; set; }

    }
}
