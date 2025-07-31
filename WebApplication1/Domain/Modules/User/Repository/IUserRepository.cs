using Application.Common;
using Domain.Modules.User.Dto.Request;

namespace Domain.Modules.User.Repository;

public interface IUserRepository
{
    Task<PagedResult<Entity.User>> GetPagedAsync(SearchUserRequest request);
    
    Task<Entity.User?> GetByIdAsync(int id);
    
    Task<bool> IsUserNameExistsAsync(string userName, int? excludeId = null);
    
    Task<bool> IsEmailExistsAsync(string email, int? excludeId = null);
    
    Task<Entity.User> CreateAsync(Entity.User user);
    
    Task<Entity.User?> UpdateAsync(Entity.User user);
    
    Task<bool> DeleteAsync(int id);
    
    Task<Entity.User?> GetUserInfoAsync(string userName, string password);
}
