using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Helpers
{
    public class AuthorResourceParmeters
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = (value > pageSize) ? MaxPageSize : value;
            }
        }
    }
}
