using Application.Common;
using Domain.Modules.Category.Dto.Request;
using Domain.Modules.Category.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Modules.Category.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<Domain.Modules.Category.Entity.Category>> GetPagedAsync(SearchCategoryRequest request)
    {
        var query = _context.Categories.Include(c => c.ParentCategory).AsQueryable();

        // Lọc theo điều kiện
        if (!string.IsNullOrWhiteSpace(request.KeyWord))
            query = query.Where(c => c.Name.Contains(request.KeyWord));

        if (!string.IsNullOrWhiteSpace(request.PageKey))
            query = query.Where(c => c.PageKey.Contains(request.PageKey));

        if (request.ParentCategoryId.HasValue)
            query = query.Where(c => c.ParentCategoryId == request.ParentCategoryId);

        if (request.Status.HasValue)
            query = query.Where(c => (int)c.Status == request.Status);

        // Sắp xếp
        if (request.SortBy != null && request.SortOrder != null)
        {
            query = ApplySorting(query, request.SortBy, request.SortOrder);
        }

        var totalCount = await query.CountAsync();
        
        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PagedResult<Domain.Modules.Category.Entity.Category>(items, totalCount, request.PageSize, request.PageNumber);
    }

    public async Task<Domain.Modules.Category.Entity.Category?> GetByIdAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.ParentCategory)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> IsNameExistsAsync(string name, int? excludeId = null)
    {
        var query = _context.Categories.Where(c => c.Name == name);
        
        if (excludeId.HasValue)
            query = query.Where(c => c.Id != excludeId);

        return await query.AnyAsync();
    }

    public async Task<bool> IsParentExistsAsync(int parentId)
    {
        return await _context.Categories.AnyAsync(c => c.Id == parentId);
    }

    public async Task<bool> HasChildrenAsync(int parentId)
    {
        return await _context.Categories.AnyAsync(c => c.ParentCategoryId == parentId);
    }

    public async Task<Domain.Modules.Category.Entity.Category> CreateAsync(Domain.Modules.Category.Entity.Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        
        // Load parent category
        await _context.Entry(category)
            .Reference(c => c.ParentCategory)
            .LoadAsync();

        return category;
    }

    public async Task<Domain.Modules.Category.Entity.Category> UpdateAsync(Domain.Modules.Category.Entity.Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        
        // Load parent category
        await _context.Entry(category)
            .Reference(c => c.ParentCategory)
            .LoadAsync();

        return category;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> CheckCategoryExistsAsync(int categoryId)
    {
        return await _context.Categories.AnyAsync(c => c.Id == categoryId);
    }

    // Áp dụng sắp xếp
    private static IQueryable<Domain.Modules.Category.Entity.Category> ApplySorting(IQueryable<Domain.Modules.Category.Entity.Category> query, string sortBy, string sortOrder)
    {
        var isDescending = sortOrder.ToUpper() == "DESC";

        return sortBy.ToLower() switch
        {
            "name" => isDescending 
                ? query.OrderByDescending(c => c.Name) 
                : query.OrderBy(c => c.Name),
            "pagekey" => isDescending 
                ? query.OrderByDescending(c => c.PageKey) 
                : query.OrderBy(c => c.PageKey),
            "status" => isDescending 
                ? query.OrderByDescending(c => c.Status) 
                : query.OrderBy(c => c.Status),
            _ => isDescending 
                ? query.OrderByDescending(c => c.CreatedAt) 
                : query.OrderBy(c => c.CreatedAt)
        };
    }
}
