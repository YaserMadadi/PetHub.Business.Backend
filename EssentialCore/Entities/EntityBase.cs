using EssentialCore.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities
{
    public class EntityBase : IEntityBase
    {
        private EntityBase()
        {
            this.Info = new Info("test", "test");

            this.Timestamp = new byte[1] { 0x0 };
        }

        public EntityBase(int id) : this()
        {
            this.Id = id;
        }

        public EntityBase(int id, byte[] timeStamp) : this(id)
        {
            this.Timestamp = timeStamp ?? new byte[1] { 0x0 };
        }

        public EntityBase(int id, byte[] timeStamp, Info info) : this(id, timeStamp)
        {
            this.Info = info;
        }

        public EntityBase(Info info) : this(0, default, info)
        {

        }





        public int Id { get; set; }

        public byte[] Timestamp { get; set; }

        public string? Descriptor { get; set; } = string.Empty;

        public Info Info { get; init; }


        //public Paginate Paginate { get; set; }

        public bool IsNew
        {
            get
            {
                return Id == 0;
            }

        }



        public static bool Confirm(IEntityBase enttiy)
        {
            return enttiy != null && enttiy.Id > 0;
        }

        public bool Confirm()
        {
            return EntityBase.Confirm(this);
        }

        public virtual bool Validate()
        {
            return true;
        }
    }
}
