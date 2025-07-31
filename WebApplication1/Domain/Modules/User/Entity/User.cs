using System.ComponentModel.DataAnnotations;
using Application.Entities;
using Domain.Enum;

namespace Domain.Modules.User.Entity;

public class User : DatimeTrackerEntity
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Gender { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string? ImageUrl { get; set; }
    public Status Status { get; set; } = Status.Active;
}
