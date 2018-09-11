using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class Pcctv
    {
        public string Pid { get; set; }
        public string Id { get; set; }
        public int? Pcctvlevel { get; set; }
        public string Pcctvname { get; set; }
        public string Classification { get; set; }
        public string Remark { get; set; }
    }
}
