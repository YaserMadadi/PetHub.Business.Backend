using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Pagination
{
    public class Paginate
    {
        public Paginate() : this(100)
        {

        }

        public Paginate(int recordPerPage) : this(recordPerPage, 1)
        {

        }

        public Paginate(int recordPerPage, int currentPage) : this(recordPerPage, currentPage, 1)
        {
        }

        public Paginate(int recordPerPage, int currentPage, int pageCount)
        {
            this.RecordPerPage = recordPerPage;

            this.CurrentPage = currentPage;

            this.PageCount = pageCount;
        }


        public int CurrentPage { get; set; }

        //[JsonIgnore]
        public int PageCount { get; set; }

        //[JsonIgnore]
        public int RecordPerPage { get; set; }

    }
}
