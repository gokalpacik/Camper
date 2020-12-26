using Camper.Services.CampFinder.Entities;
using GloboTicket.Services.EventCatalog.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camper.Web.CampFinder.Repositories
{
    public class CampSiteRepository : ICampSiteRepository
    {
        private readonly CampFinderDbContext _campFinderDbContext;
        private readonly ILogger<CampSiteRepository> logger;


        public CampSiteRepository(CampFinderDbContext campFinderDbContext, ILogger<CampSiteRepository> logger)
        {
            _campFinderDbContext = campFinderDbContext;
            this.logger = logger;
        }

        public async Task<IEnumerable<CampSite>> GetCampSites(Guid categoryId)
        {
            try
            {
                var campSites = await _campFinderDbContext.CampSites
                    .Include(x => x.Category)
                    .Where(x => (x.CategoryId == categoryId || categoryId == Guid.Empty)).ToListAsync();

                logger.LogDebug("Found {CampSiteCount} camp sites in the database", campSites.Count);

                return campSites;
            }
            catch (Exception e)
            {
                logger.LogError(e, "An exception occurred while loading campsites");
                throw;
            }
        }

        public async Task<CampSite> GetCampSiteById(Guid campSiteId)
        {
            var campSiteItem = await _campFinderDbContext.CampSites.Include(x => x.Category).Where(x => x.CampSiteId == campSiteId).FirstOrDefaultAsync();

            if (campSiteItem is null)
            {
                logger.LogInformation("Unable to locate camp site in the database");
            }

            return campSiteItem;
        }       
    }
}
