using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Data
{
    public class UserRole : BaseEntity
    {
        [Key]
        public int UserRoleId { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }


        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
