using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class VihiclePP
    {
        public string Id { get; set; }
        public string GpsEdiVihicle { get; set; }
        public string VihiclePPP { get; set; }
        public string VihiclePPC { get; set; }
        public string VihiclePPC1 { get; set; }
        public string VihiclePPD { get; set; }
        public DateTime? VihiclePPT { get; set; }
        public decimal? VihicleLat { get; set; }
        public decimal? VihicleLon { get; set; }
    }
}
