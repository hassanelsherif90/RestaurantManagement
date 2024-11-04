


using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.TableRe
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        public TableRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }


    }
}
