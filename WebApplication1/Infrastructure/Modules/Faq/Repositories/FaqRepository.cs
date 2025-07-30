using Application.Common;
using Domain.Modules.Faq.Dto.Request;
using Domain.Modules.Faq.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Modules.Faq.Repositories;

public class FaqRepository : IFaqRepository
{
    private readonly AppDbContext _context;
    
    public FaqRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<Domain.Modules.Faq.Entity.Faq>> GetPagedAsync(SearchFaqRequest request)
    {
        var query = _context.Faqs.AsQueryable();

        // Lọc theo điều kiện
        if (!string.IsNullOrWhiteSpace(request.KeyWord))
            query = query.Where(f => f.Question.Contains(request.KeyWord) || f.Answer.Contains(request.KeyWord));

        if (request.Status.HasValue)
            query = query.Where(f => (int)f.Status == request.Status);

        // Sắp xếp
        if (request.SortBy != null && request.SortOrder != null)
        {
            query =  ApplySorting(query, request.SortBy, request.SortOrder);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PagedResult<Domain.Modules.Faq.Entity.Faq>(items, totalCount, request.PageSize, request.PageNumber);
    }

    public async Task<Domain.Modules.Faq.Entity.Faq?> GetByIdAsync(int id)
    {
        return await _context.Faqs
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<bool> IsQuestionExistsAsync(string question, int? excludeId = null)
    {
        var query = _context.Faqs.Where(f => f.Question == question);
        if (excludeId.HasValue)
            query = query.Where(f => f.Id != excludeId.Value);

        return await query.AnyAsync();
    }

    public async Task<bool> CheckCategoryExistsAsync(int categoryId)
    {
        return await _context.Faqs.AnyAsync(f => f.CategoryId == categoryId);
    }
    
    public async Task<Domain.Modules.Faq.Entity.Faq> CreateAsync(Domain.Modules.Faq.Entity.Faq faq)
    {
        _context.Faqs.Add(faq);
        await _context.SaveChangesAsync();
        return faq;
    }
    
    public async Task<Domain.Modules.Faq.Entity.Faq?> UpdateAsync(Domain.Modules.Faq.Entity.Faq faq)
    {
        _context.Faqs.Update(faq);
        await _context.SaveChangesAsync();
        return faq;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var faq = await GetByIdAsync(id);
        if (faq == null)
            return false;

        _context.Faqs.Remove(faq);
        await _context.SaveChangesAsync();
        return true;
    }
    
    private static IOrderedQueryable<Domain.Modules.Faq.Entity.Faq> ApplySorting(IQueryable<Domain.Modules.Faq.Entity.Faq> query, string sortBy, string sortOrder)
    {
        var isDescending = sortOrder.ToUpper() == "DESC";

        return sortBy.ToLower() switch
        {
            "question" => isDescending 
                ? query.OrderByDescending(f => f.Question) 
                : query.OrderBy(f => f.Question),
            "answer" => isDescending 
                ? query.OrderByDescending(f => f.Answer) 
                : query.OrderBy(f => f.Answer),
            "status" => isDescending 
                ? query.OrderByDescending(f => f.Status) 
                : query.OrderBy(f => f.Status),
            _ => isDescending 
                ? query.OrderByDescending(f => f.CreatedAt) 
                : query.OrderBy(f => f.CreatedAt)
        };
    }
}
