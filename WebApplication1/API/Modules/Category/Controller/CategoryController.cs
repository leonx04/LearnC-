using Domain.Modules.Category.Dto.Request;
using Domain.Modules.Category.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Category.Controller;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] SearchCategoryRequest request)
    {
        var result = await categoryService.GetPagedAsync(request);
        return Ok(new
        {
            success = true,
            message = "Lấy danh sách danh mục thành công",
            data = result
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var result = await categoryService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { success = false, message = "Không tìm thấy danh mục" });

        return Ok(new
        {
            success = true,
            message = "Lấy thông tin danh mục thành công",
            data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        try
        {
            var result = await categoryService.CreateAsync(request);
            return CreatedAtAction(nameof(GetCategoryById), new { id = result.Id }, new
            {
                success = true,
                message = "Tạo danh mục thành công",
                data = result
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryRequest request)
    {
        try
        {
            var result = await categoryService.UpdateAsync(id, request);
            if (result == null)
                return NotFound(new { success = false, message = "Không tìm thấy danh mục" });

            return Ok(new
            {
                success = true,
                message = "Cập nhật danh mục thành công",
                data = result
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            var result = await categoryService.DeleteAsync(id);
            if (!result)
                return NotFound(new { success = false, message = "Không tìm thấy danh mục" });

            return Ok(new { success = true, message = "Xóa danh mục thành công" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}
