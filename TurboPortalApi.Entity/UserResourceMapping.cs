using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPortalApi.Entity
{
    public class UserResourceMapping : BaseEntity
    {
        public int UserId { get; set; }
        public int ResourceId { get; set; }
        public int OrderNumber { get; set; }
        public string Remark { get; set; }
    }
}
