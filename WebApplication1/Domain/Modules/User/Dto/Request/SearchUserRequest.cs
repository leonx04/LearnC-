using Application.Common;
using Domain.Enum;

namespace Domain.Modules.User.Dto.Request;

public class SearchUserRequest : SearchQuery
{
    public Role Role { get; set; } = Role.User;
}
