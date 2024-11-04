using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.OrderItemRepo
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
