using System.ComponentModel.DataAnnotations;
using Application.Entities;
using Domain.Enum;
namespace Domain.Modules.Faq.Entity;

public class Faq : DatimeTrackerEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Câu hỏi là bắt buộc.")]
    [MaxLength(1000, ErrorMessage = "Câu hỏi không được vượt quá 1000 ký tự.")]
    public string Question { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Câu trả lời là bắt buộc.")]
    [MaxLength(5000, ErrorMessage = "Câu trả lời không được vượt quá 5000 ký tự.")]
    public string Answer { get; set; } = string.Empty;
    
    public int CategoryId { get; set; }
    
    public Category.Entity.Category? Category { get; set; }
    
    public Status Status { get; set; } = Status.Active;
}
