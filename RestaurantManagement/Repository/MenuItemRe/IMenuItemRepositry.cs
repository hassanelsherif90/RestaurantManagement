﻿using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.MenuItemRe
{
    public interface IMenuItemRepositry : IRepository<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetAvavilableItems();
        Task<MenuItem> GetMenuItemWithDetails(int menuItemId);
        Task<IEnumerable<MenuItem>> GetItemByCategory(int categoryId);
    }
}
