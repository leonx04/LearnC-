using Domain.Enum;

namespace Domain.Modules.User.Dto.Response;

public class UserInfoResponse
{
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Role Role { get; set; }
}
