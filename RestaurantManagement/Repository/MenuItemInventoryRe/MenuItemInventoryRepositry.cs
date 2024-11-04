using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.MenuItemInventoryRe
{
    public class MenuItemInventoryRepositry : Repository<MenuItemInventory>, IMenuItemInventoryRepository
    {
        public MenuItemInventoryRepositry(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
