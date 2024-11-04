using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.MenuItemInventoryRe
{
    public class MenuItemInventoryRepositry : Repository<MenuItemInventory>, IMenuItemInventoryRepositry
    {
        public MenuItemInventoryRepositry(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
