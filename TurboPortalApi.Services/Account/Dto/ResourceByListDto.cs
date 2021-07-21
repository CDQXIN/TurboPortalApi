using System;
using System.Collections.Generic;
using System.Text;
using TurboPortalApi.Entity;

namespace TurboPortalApi.Services.Account.Dto
{
    public class ResourceByListDto: BaseEntityDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string LessonUrl { get; set; }
        public string ImageUrl { get; set; }
        public int Sort { get; set; }
        public int VisitNum { get; set; }
        public byte Status { get; set; }

        public static ResourceByListDto ToDto(Resources resource)
        {
            ResourceByListDto dto = new ResourceByListDto()
            {
                Id= resource.Id,
                Author = resource.Author,
                ImageUrl = resource.ImageUrl,
                LessonUrl = resource.LessonUrl,
                Name = resource.Name,
                Sort = resource.Sort,
                Status = resource.Status,
                VisitNum = resource.VisitNum
            };
            return dto;
        }
    }

}
