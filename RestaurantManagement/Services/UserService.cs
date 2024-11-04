using RestaurantManagement.Models.Data;
using RestaurantManagement.Repository;
using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = _unitOfWork.Users.GetAllAsync().Result;
            var userViewModelList = new List<UserViewModel>();

            foreach (User user in users)
            {
                var userViewModel = new UserViewModel
                {
                    Id = user.UserId,
                    Email = user.Email,
                    Role = user.UserRoles.ToString(),
                    Username = user.Username,
                };

                userViewModelList.Add(userViewModel);
            }

            return userViewModelList;
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _unitOfWork.Users.GetByIdAsync(id).Result;
            var userViewModel = new UserViewModel
            {
                Id = user.UserId,
                Email = user.Email,
                Role = user.UserRoles.ToString(),
                Username = user.Username,
            };

            return userViewModel;
        }

        public void CreateUser(UserViewModel model)
        {
            var user = new User
            {
                UserId = model.Id,
                Email = model.Email,
                Username = model.Username,
                UserRoles = model.Role.Select(roleId => new UserRole
                {
                    RoleId = roleId, // تأكد من أن roleId هو من النوع المناسب
                    UserId = model.Id // أو استخدم أي قيمة مناسبة لمعرف المستخدم
                }).ToList()
            };

            _unitOfWork.Users.AddAsync(user).Wait();
            _unitOfWork.CompleteAsync().Wait();
        }

        public void UpdateUser(UserViewModel model)
        {
            var user = _unitOfWork.Users.GetByIdAsync(model.Id).Result;
            // تحديث الخصائص حسب الحاجة
            user.Username = model.Username;
            user.Email = model.Email;
            _unitOfWork.Users.UpdateAsync(user);
            _unitOfWork.CompleteAsync().Wait();
        }

        public void DeleteUser(int id)
        {
            var user = _unitOfWork.Users.GetByIdAsync(id).Result;
            _unitOfWork.Users.RemoveAsync(user);
            _unitOfWork.CompleteAsync().Wait();
        }
    }
}
