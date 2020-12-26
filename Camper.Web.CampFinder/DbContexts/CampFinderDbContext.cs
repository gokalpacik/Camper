using System;
using Camper.Services.CampFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Services.EventCatalog.DbContexts
{
    public class CampFinderDbContext : DbContext
    {
        public CampFinderDbContext(DbContextOptions<CampFinderDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CampSite> CampSites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var privateCampGuid = Guid.NewGuid();
            var nationalParkGuid = Guid.NewGuid();

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = privateCampGuid,
                Name = "Private Camps"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = nationalParkGuid,
                Name = "Naitonal Park Camps"
            });

            modelBuilder.Entity<CampSite>().HasData(new CampSite
            {
                CampSiteId = Guid.NewGuid(),
                Name = "Semizkum Tabiat Parkı",
                Location = "İstanbul",
                Description = "İstanbul'un Silivri ilçesinde bulunan bir kamp alanı",
                ImageUrl = "https://blog.flypgs.com/wp-content/uploads/2018/05/istanbul-yakini-kamp-yapilacak-yerler.jpg",
                CategoryId = privateCampGuid,
                CreateTime = DateTime.Now
            });

            modelBuilder.Entity<CampSite>().HasData(new CampSite
            {
                CampSiteId = Guid.NewGuid(),
                Name = "Gökçetepe Tabiat Parkı",
                Location = "Edirne",
                Description = "Edirne'nin Keşan ilçesinde bulunan bir milli park ve tabiat parkı",
                ImageUrl = "https://gokcetepetabiatparki.com/wp-content/uploads/2020/03/Zipline.jpg",
                CategoryId = nationalParkGuid,
                CreateTime = DateTime.Now
            });
        }
    }
}
