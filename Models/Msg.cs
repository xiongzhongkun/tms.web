using System;

namespace tms.Models
{
    public class Msg
    {
        public Msg()
        {
            flag = false;
        }
        public bool flag { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public object other { get; set; }
    }
}