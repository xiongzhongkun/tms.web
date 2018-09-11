using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class SysRole
    {
        public string Id { get; set; }
        public string CreateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string RoleName { get; set; }
        public string RoleType { get; set; }
        public bool? IsSys { get; set; }
        public string UpdateId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
