using Camper.Services.CampFinder.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camper.Web.CampFinder.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string categoryId);
    }
}
