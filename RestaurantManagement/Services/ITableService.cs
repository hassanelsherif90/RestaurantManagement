using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Services
{
    public interface ITableService
    {
        IEnumerable<TableViewModel> GetAllTables();
        TableViewModel GetTableById(int id);
        void CreateTable(TableViewModel model);
        void UpdateTable(TableViewModel model);
        void DeleteTable(int id);
    }
}
