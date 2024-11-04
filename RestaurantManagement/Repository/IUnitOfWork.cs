using RestaurantManagement.Repository.CategoryRe;
using RestaurantManagement.Repository.InventoryRe;
using RestaurantManagement.Repository.MenuItemInventoryRe;
using RestaurantManagement.Repository.MenuItemRe;
using RestaurantManagement.Repository.OrderItemRepo;
using RestaurantManagement.Repository.OrderRe;
using RestaurantManagement.Repository.ReservationRe;
using RestaurantManagement.Repository.SupplierRe;
using RestaurantManagement.Repository.TableRe;
using RestaurantManagement.Repository.UserRe;

namespace RestaurantManagement.Repository
{

    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IInventoryRepository Inventory { get; }
        IMenuItemRepository MenuItems { get; }
        IMenuItemInventoryRepository menuItemInventory { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository orderItem { get; }
        IReservationRepository Reservations { get; }
        IRoleRepository Roles { get; }
        ISupplierRepository Suppliers { get; }
        ITableRepository Tables { get; }
        IUserRepository Users { get; }
        IUserRoleRepository userRole { get; }

        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }

}
