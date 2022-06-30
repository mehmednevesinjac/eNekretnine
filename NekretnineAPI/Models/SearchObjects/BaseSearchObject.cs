using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SearchObjects
{
    public class BaseSearchObject
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int? TotalCount { get; set; }
        public int? TotalPages { get; set; }
        public bool? HasPrevious => Page > 1;
        public bool? HasNext => Page < TotalPages;

    }
}
