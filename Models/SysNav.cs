using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class SysNav
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string NavName { get; set; }
        public string SubTitle { get; set; }
        public string ActionType { get; set; }
        public string LinkUrl { get; set; }
        public string Remark { get; set; }
        public bool? IsSys { get; set; }
        public bool? IsLock { get; set; }
        public int? SortId { get; set; }
    }
}
