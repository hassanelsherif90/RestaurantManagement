using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.CategoryRe
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }

        public async Task<IEnumerable<Category>> GetActiveCategories()
        {
            return
                await _entities
                .Where(C => !C.IsDeleted && C.IsActive)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryWithMenuItems(int categoryId)
        {
            return await _entities.Include(c => c.MenuItems)
                .FirstOrDefaultAsync(c => c.CategoryId == categoryId && !c.IsDeleted);
        }
    }
}
