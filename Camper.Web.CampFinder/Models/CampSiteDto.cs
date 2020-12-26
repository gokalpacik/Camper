using System;

namespace Camper.Services.CampFinder.Models
{
    public class CampSiteDto
    {
        public Guid CampSiteId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
