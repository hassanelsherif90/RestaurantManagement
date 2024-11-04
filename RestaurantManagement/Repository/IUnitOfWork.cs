using RestaurantManagement.Repository.CategoryRe;
using RestaurantManagement.Repository.InventoryRe;
using RestaurantManagement.Repository.MenuItemRe;
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
        IMenuItemRepositry MenuItems { get; }
        IOrderRepository Orders { get; }
        ITableRepository Tables { get; }
        IReservationRepository Reservations { get; }
        IUserRepository Users { get; }
        IInventoryRepository Inventory { get; }
        ISupplierRepository Suppliers { get; }

        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }

}
