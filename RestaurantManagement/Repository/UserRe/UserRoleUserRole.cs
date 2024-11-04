using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.UserRe
{
    public class UserRoleUserRole : Repository<UserRole>, IUserRoleUserRole
    {
        public UserRoleUserRole(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
