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
        /// <summary>
        /// 过滤条件
        /// </summary>
        public string BirthPlace { get; set; }
        public string SerachQuery { get; set; }
        public string StoryBy { get; set; } = "Name";

        private int pageSize = 10;
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
