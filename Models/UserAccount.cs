using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class UserAccount
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public DateTime? AddTime { get; set; }
        public string GpsUserId { get; set; }
    }
}
