using System;
using System.Collections.Generic;

namespace Camper.Services.CampFinder.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<CampSite> CampSites { get; set; }
    }
}
