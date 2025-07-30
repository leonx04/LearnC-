using Application.Common;
using Domain.Enum;
using Domain.Modules.Category.Dto.Request;
using Domain.Modules.Category.Dto.Response;
using Domain.Modules.Category.Repository;
using Domain.Modules.Category.Services;
using Domain.Modules.Category.Entity;

namespace Infrastructure.Modules.Category.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<CategoryResponse>> GetPagedAsync(SearchCategoryRequest request)
    {
        var result = await _repository.GetPagedAsync(request);
        
        var responses = result.Items.Select(MapToResponse);
        
        return new PagedResult<CategoryResponse>(
            responses, 
            result.TotalItemsCount, 
            request.PageSize, 
            request.PageNumber);
    }

    public async Task<CategoryResponse?> GetByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        return category != null ? MapToResponse(category) : null;
    }

    public async Task<CategoryResponse> CreateAsync(CreateCategoryRequest request)
    {
        // Kiểm tra tên danh mục đã tồn tại
        if (await _repository.IsNameExistsAsync(request.Name))
            throw new InvalidOperationException("Tên danh mục đã tồn tại");

        // Kiểm tra danh mục cha có tồn tại
        if (request.ParentCategoryId.HasValue && 
            !await _repository.IsParentExistsAsync(request.ParentCategoryId.Value))
            throw new InvalidOperationException("Danh mục cha không tồn tại");

        var category = new Domain.Modules.Category.Entity.Category
        {
            Name = request.Name,
            PageKey = request.PageKey,
            ParentCategoryId = request.ParentCategoryId,
            Status = (Status)request.Status
        };

        var createdCategory = await _repository.CreateAsync(category);
        return MapToResponse(createdCategory);
    }

    public async Task<CategoryResponse?> UpdateAsync(int id, UpdateCategoryRequest request)
    {
        var existingCategory = await _repository.GetByIdAsync(id);
        if (existingCategory == null) return null;

        // Kiểm tra tên danh mục đã tồn tại (loại trừ chính nó)
        if (await _repository.IsNameExistsAsync(request.Name, id))
            throw new InvalidOperationException("Tên danh mục đã tồn tại");

        // Kiểm tra danh mục cha
        if (request.ParentCategoryId.HasValue)
        {
            if (!await _repository.IsParentExistsAsync(request.ParentCategoryId.Value))
                throw new InvalidOperationException("Danh mục cha không tồn tại");

            if (request.ParentCategoryId.Value == id)
                throw new InvalidOperationException("Danh mục không thể là cha của chính nó");
        }

        // Cập nhật thông tin
        existingCategory.Name = request.Name;
        existingCategory.PageKey = request.PageKey;
        existingCategory.ParentCategoryId = request.ParentCategoryId;
        existingCategory.Status = (Status)request.Status;

        var updatedCategory = await _repository.UpdateAsync(existingCategory);
        return MapToResponse(updatedCategory);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return false;

        // Kiểm tra có danh mục con không
        if (await _repository.HasChildrenAsync(id))
            throw new InvalidOperationException("Không thể xóa danh mục có danh mục con");

        return await _repository.DeleteAsync(id);
    }

    // Chuyển đổi Entity sang Response DTO
    private static CategoryResponse MapToResponse(Domain.Modules.Category.Entity.Category category)
    {
        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            PageKey = category.PageKey,
            ParentCategoryId = category.ParentCategoryId,
            ParentCategoryName = category.ParentCategory?.Name,
            Status = category.Status,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        };
    }
}
