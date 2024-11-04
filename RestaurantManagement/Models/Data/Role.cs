using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Data
{
    public class Role : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }

        [Required, StringLength(50)]
        public string RoleName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation Property
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
