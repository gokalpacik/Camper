using System;
using System.ComponentModel.DataAnnotations;

namespace Camper.Services.CampFinder.Entities
{
    public class CampSite
    {
        [Required]
        public Guid CampSiteId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
