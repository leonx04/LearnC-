using Application.Common;
using Domain.Modules.Faq.Dto.Request;

namespace Domain.Modules.Faq.Repository;

public interface IFaqRepository
{
    // Lấy danh sách phân trang
    Task<PagedResult<Entity.Faq>> GetPagedAsync(SearchFaqRequest request);
    
    // Lấy FAQ theo ID
    Task<Entity.Faq?> GetByIdAsync(int id);
    
    // Kiểm tra câu hỏi đã tồn tại
    Task<bool> IsQuestionExistsAsync(string question, int? excludeId = null);
    
    // Tạo mới FAQ
    Task<Entity.Faq> CreateAsync(Entity.Faq faq);
    
    // Cập nhật FAQ
    Task<Entity.Faq?> UpdateAsync(Entity.Faq faq);
    
    // Xóa FAQ
    Task<bool> DeleteAsync(int id);
}
