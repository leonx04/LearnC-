using Application.Common;
using Domain.Enum;
using Domain.Modules.User.Dto.Request;
using Domain.Modules.User.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Modules.User.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<PagedResult<Domain.Modules.User.Entity.User>> GetPagedAsync(SearchUserRequest request)
    {
        var query = _context.Users.AsQueryable();

        // Lọc theo điều kiện
        if (!string.IsNullOrWhiteSpace(request.KeyWord))
            query = query.Where(u => u.UserName.Contains(request.KeyWord) || u.Email.Contains(request.KeyWord) || 
                                     u.FirstName.Contains(request.KeyWord) || u.LastName.Contains(request.KeyWord));

        if (request.Role == Role.Admin)
            query = query.Where(u => (int)u.Role == (int)request.Role);

        if (request.Status.HasValue)
            query = query.Where(u => (int)u.Status == request.Status);

        if (request.SortBy != null && request.SortOrder != null)
        {
            query = ApplySorting(query, request.SortBy, request.SortOrder);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PagedResult<Domain.Modules.User.Entity.User>(items, totalCount, request.PageSize, request.PageNumber);
    }

    public Task<Domain.Modules.User.Entity.User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserNameExistsAsync(string userName, int? excludeId = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailExistsAsync(string email, int? excludeId = null)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Modules.User.Entity.User> CreateAsync(Domain.Modules.User.Entity.User user)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Modules.User.Entity.User?> UpdateAsync(Domain.Modules.User.Entity.User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Modules.User.Entity.User?> GetUserInfoAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }
    
    private IQueryable<Domain.Modules.User.Entity.User> ApplySorting(IQueryable<Domain.Modules.User.Entity.User> query, string sortBy, string sortOrder)
    {
        if (sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase))
        {
            return sortBy switch
            {
                "UserName" => query.OrderBy(u => u.UserName),
                "Email" => query.OrderBy(u => u.Email),
                "FirstName" => query.OrderBy(u => u.FirstName),
                "LastName" => query.OrderBy(u => u.LastName),
                "Role" => query.OrderBy(u => u.Role),
                "Status" => query.OrderBy(u => u.Status),
                _ => query
            };
        }
        else
        {
            return sortBy switch
            {
                "UserName" => query.OrderByDescending(u => u.UserName),
                "Email" => query.OrderByDescending(u => u.Email),
                "FirstName" => query.OrderByDescending(u => u.FirstName),   
                "LastName" => query.OrderByDescending(u => u.LastName),
                "Role" => query.OrderByDescending(u => u.Role),
                "Status" => query.OrderByDescending(u => u.Status),
                _ => query
            };
        }
    }
}
