using Application.Common;
using Domain.Modules.Category.Dto.Request;
using Domain.Modules.Category.Dto.Response;

namespace Domain.Modules.Category.Services;

public interface ICategoryService
{
    // Lấy danh sách phân trang
    Task<PagedResult<CategoryResponse>> GetPagedAsync(SearchCategoryRequest request);
    
    // Lấy danh mục theo ID
    Task<CategoryResponse?> GetByIdAsync(int id);
    
    // Tạo mới danh mục
    Task<CategoryResponse> CreateAsync(CreateCategoryRequest request);
    
    // Cập nhật danh mục
    Task<CategoryResponse?> UpdateAsync(int id, UpdateCategoryRequest request);
    
    // Xóa danh mục
    Task<bool> DeleteAsync(int id);
}
