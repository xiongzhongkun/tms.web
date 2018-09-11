using System;
using System.Collections.Generic;

namespace tms.Models
{
    public partial class SysRoleValue
    {
        public string Id { get; set; }
        public string CreateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string RoleId { get; set; }
        public string NavName { get; set; }
        public string ActionType { get; set; }
        public string UpdateId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
