using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Log
{
    public class CommandParameter : EntityBase, IEntityBase
    {
        public CommandParameter() : base(CommandParameter.Informer)
        {

        }

        public static Info Informer { get; private set; } = new Info("Log", "CommandParameter", "Command Parameter");

        public Exception Log { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string TypeName { get; set; }
    }
}
