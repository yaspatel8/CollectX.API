using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.Common
{
    public class CommonPagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public string? StrSearch { get; set; }
    }
}
