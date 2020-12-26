using GloboTicket.Services.EventCatalog.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Camper.Services.CampFinder.Entities;

namespace Camper.Web.CampFinder.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CampFinderDbContext _campFinderDbContext;

        public CategoryRepository(CampFinderDbContext campFinderDbContext)
        {
            _campFinderDbContext = campFinderDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _campFinderDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(string categoryId)
        {
            return await _campFinderDbContext.Categories.Where(x => x.CategoryId.ToString() == categoryId).FirstOrDefaultAsync();
        }
    }
}


