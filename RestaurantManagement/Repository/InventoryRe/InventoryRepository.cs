using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.InventoryRe
{
    public class InventoryRepository : Repository<InventoryItem>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
