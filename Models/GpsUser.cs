using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class GpsUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserShortname { get; set; }
        public string UserCode { get; set; }
        public decimal? UserBalance { get; set; }
        public string UserAddP { get; set; }
        public string UserAddC { get; set; }
        public string UserAddD { get; set; }
        public string UserCon { get; set; }
        public string UserConTel { get; set; }
        public string UserConEmail { get; set; }
        public string UserStatus { get; set; }
        public string EdiStatus { get; set; }
        public DateTime? AddTime { get; set; }
    }
}
