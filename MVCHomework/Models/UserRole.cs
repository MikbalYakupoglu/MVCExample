using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHomework.Models;

public class UserRole
{
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    public Role Role { get; set; }
}