using Domain.Modules.Faq.Dto.Request;
using Domain.Modules.Faq.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Faq.Controller;

[ApiController]
[Route("api/faq")]
public class FaqController : ControllerBase
{
    private readonly IFaqService faqService;
    public FaqController(IFaqService faqService)
    {
        this.faqService = faqService;
    }

    [HttpGet]
    public async Task<IActionResult> GetFaqs([FromQuery] SearchFaqRequest request)
    {
        var result = await faqService.GetPagedAsync(request);
    
        string message = request.GroupByCategory == true 
            ? "Lấy danh sách câu hỏi thường gặp theo danh mục thành công"
            : "Lấy danh sách câu hỏi thường gặp thành công";
    
        return Ok(new
        {
            success = true,
            message = message,
            data = result
        });
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFaqById(int id)
    {
        var result = await faqService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { success = false, message = "Không tìm thấy câu hỏi thường gặp" });

        return Ok(new
        {
            success = true,
            message = "Lấy thông tin câu hỏi thường gặp thành công",
            data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateFaq([FromBody] CreateFaqRequest request)
    {
        try
        {
            var result = await faqService.CreateAsync(request);
            return CreatedAtAction(nameof(GetFaqById), new { id = result.Id }, new
            {
                success = true,
                message = "Tạo câu hỏi thường gặp thành công",
                data = result
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateFaq(int id, [FromBody] UpdateFaqRequest request)
    {
        try
        {
            var result = await faqService.UpdateAsync(id, request);
            if (result == null)
                return NotFound(new { success = false, message = "Không tìm thấy câu hỏi thường gặp" });
            return Ok(new
            {
                success = true,
                message = "Cập nhật câu hỏi thường gặp thành công",
                data = result
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFaq(int id)
    {
        try
        {
            var result = await faqService.DeleteAsync(id);
            return Ok(new
            {
                success = true,
                message = "Xóa câu hỏi thường gặp thành công",
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}
