using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class GpsEdi
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string GpsEdiType { get; set; }
        public string GpsEdiStatus { get; set; }
        public DateTime? GpsEdiTime { get; set; }
        public string GpsEdiVihicle { get; set; }
        public decimal? GpsEdiCharge { get; set; }
        public string GpsEdiId { get; set; }
    }
}
