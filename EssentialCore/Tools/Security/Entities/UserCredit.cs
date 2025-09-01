using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Security.Entities
{
    public class UserCredit
    {
        public int Impersonation_Id { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public int Person_Id { get; set; }

        public int Employee_Id { get; set; }

        public int UserAccount_Id { get; set; } = 0;
    }
}
