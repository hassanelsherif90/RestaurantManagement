using RestaurantManagement.Models;
using RestaurantManagement.Models.Data;

namespace RestaurantManagement.Repository.UserRe
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
