using System;
using System.Collections.Generic;
using System.Text;
using TurboPortalApi.Entity;

namespace TurboPortalApi.Services.Account.Dto
{
    public class ResourceDto: BaseEntityDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string LessonUrl { get; set; }
        public string ImageUrl { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }
        public int VisitNum { get; set; }
        public byte Status { get; set; }
        public static ResourceDto ToDto(Resources resource)
        {
            ResourceDto dto = new ResourceDto()
            {
                Id = resource.Id,
                Author = resource.Author,
                ImageUrl = resource.ImageUrl,
                LessonUrl = resource.LessonUrl,
                Name = resource.Name,
                Sort = resource.Sort,
                Status = resource.Status,
                VisitNum = resource.VisitNum,
                Text = resource.Text,
                Description = resource.Description
            };
            return dto;
        }
    }
}
