using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.UserRe
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
