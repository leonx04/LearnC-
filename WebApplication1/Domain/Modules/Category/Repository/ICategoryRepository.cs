using Application.Common;
using Domain.Modules.Category.Dto.Request;

namespace Domain.Modules.Category.Repository;

public interface ICategoryRepository
{
    // Lấy danh sách phân trang
    Task<PagedResult<Entity.Category>> GetPagedAsync(SearchCategoryRequest request);
    
    // Lấy danh mục theo ID
    Task<Entity.Category?> GetByIdAsync(int id);
    
    // Kiểm tra tên danh mục đã tồn tại
    Task<bool> IsNameExistsAsync(string name, int? excludeId = null);
    
    // Kiểm tra danh mục cha có tồn tại
    Task<bool> IsParentExistsAsync(int parentId);
    
    // Kiểm tra có danh mục con không
    Task<bool> HasChildrenAsync(int parentId);
    
    // Tạo mới danh mục
    Task<Entity.Category> CreateAsync(Entity.Category category);
    
    // Cập nhật danh mục
    Task<Entity.Category> UpdateAsync(Entity.Category category);
    
    // Xóa danh mục
    Task<bool> DeleteAsync(int id);
    
    // Kiểm tra danh mục có tồn tại không
    Task<bool> CheckCategoryExistsAsync(int categoryId);
}
