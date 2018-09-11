using System;

namespace tms.Models
{
    public class LigerGridParam{
        public string workState { get; set; }
        public string carLicense { get; set; }
        public string driver { get; set; }
        public string workStatus { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string sortName { get; set; }
        public string sortOrder { get; set; }

    }
}