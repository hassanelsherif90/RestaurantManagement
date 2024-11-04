using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;



namespace RestaurantManagement.Repository.MenuItemRe
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }

        public async Task<IEnumerable<MenuItem>> GetAvavilableItems()
        {
            return await _entities
                 .Where(m => !m.IsDeleted && m.IsAvailable)
                 .Include(m => m.Category)
                 .ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetItemByCategory(int categoryId)
        {
            return await _entities
                 .Where(m => !m.IsDeleted && m.CategoryId == categoryId)
                 .ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemWithDetails(int menuItemId)
        {

            return await _entities.Include(m => m.Category)
                .Include(m => m.RequiredInventoryItems)
                    .ThenInclude(ri => ri.InventoryItem)
                .FirstOrDefaultAsync(m => m.MenuItemId == menuItemId && !m.IsDeleted);
        }
    }
}
