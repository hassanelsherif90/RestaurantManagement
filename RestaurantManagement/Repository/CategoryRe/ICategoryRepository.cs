using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.CategoryRe
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<IEnumerable<Category>> GetActiveCategories();
        Task<Category> GetCategoryWithMenuItems(int categoryId);
    }
}
