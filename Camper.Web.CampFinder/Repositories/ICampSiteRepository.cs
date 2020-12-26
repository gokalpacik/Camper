using Camper.Services.CampFinder.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camper.Web.CampFinder.Repositories
{
    public interface ICampSiteRepository
    {
        Task<IEnumerable<CampSite>> GetCampSites(Guid categoryId);
        Task<CampSite> GetCampSiteById(Guid CampSiteId);
    }
}
