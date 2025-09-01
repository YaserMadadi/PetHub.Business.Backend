using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities
{
    public interface IEntityBase 
    {
        public int Id { get; set; }


        public byte[] Timestamp { get; set; }

        public string Descriptor { get; set; }

        public Info Info { get; init; }

        //public Paginate Paginate { get; set; }

        public bool IsNew { get; }

        public bool Validate();

        public bool Confirm();
    }
}
