using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPortalApi.Entity
{
    public class Users : FullEntity
    {
        public string QQ { get; set; }
        public string Mobile { get; set; }
        public string PassWord { get; set; }
        public string NickName { get; set; }
        public DateTime RegDate { get; set; }
        public int LoginNum { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public byte Status { get; set; }
    }
}
