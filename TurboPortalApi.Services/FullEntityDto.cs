using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPortalApi.Services
{
    public class FullEntityDto : BaseEntityDto
    {
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }

    }
}
