using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Core
{
    public class Role : EntityBase, IEntityBase
    {
        public Role() : base(Informer)
        {
        }

        protected static Info Informer { get; private set; } = new Info("Core", "Role", "Role");

        public string Title { get; set; }

        public bool IsActive { get; set; }
    }
}
