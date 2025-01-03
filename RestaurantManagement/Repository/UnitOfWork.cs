﻿using Microsoft.EntityFrameworkCore.Storage;
using RestaurantManagement.Models;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _context;
        private IDbContextTransaction _transaction;

        public ICategoryRepository Categories { get; private set; }
        public IMenuItemRepository MenuItems { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public ITableRepository Tables { get; private set; }
        public IReservationRepository Reservations { get; private set; }
        public IUserRepository Users { get; private set; }
        public IInventoryRepository Inventory { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }

        public IMenuItemInventoryRepository menuItemInventory { get; private set; }

        public IOrderItemRepository orderItem { get; private set; }

        public IRoleRepository Roles { get; private set; }

        public IUserRoleRepository userRole { get; private set; }


        public UnitOfWork(ApplicationDbcontext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            MenuItems = new MenuItemRepository(context);
            Orders = new OrderRepository(context);
            Tables = new TableRepository(context);
            Reservations = new ReservationRepository(context);
            Users = new UserRepository(context);
            Inventory = new InventoryRepository(context);
            Suppliers = new SupplierRepository(context);
            menuItemInventory = new MenuItemInventoryRepositry(context);
            orderItem = new OrderItemRepository(context);
            Roles = new RoleRepository(context);
            userRole = new UserRoleRepository(context);

        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
