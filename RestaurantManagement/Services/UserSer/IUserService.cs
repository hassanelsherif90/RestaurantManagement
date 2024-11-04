using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Services.UserSer
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetUserById(int id);
        void CreateUser(UserViewModel model);
        void UpdateUser(UserViewModel model);
        void DeleteUser(int id);
    }
}
