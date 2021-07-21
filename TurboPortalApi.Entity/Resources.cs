using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPortalApi.Entity
{
    public class Resources : FullEntity
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

    }
}
