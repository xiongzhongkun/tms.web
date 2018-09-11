using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class VihicleData
    {
        public string Id { get; set; }
        public string GpsEdiVihicle { get; set; }
        public string FromEdi { get; set; }
        public string FromUser { get; set; }
        public DateTime? EdiTimes { get; set; }
        public DateTime? EdiUpdate { get; set; }
    }
}
