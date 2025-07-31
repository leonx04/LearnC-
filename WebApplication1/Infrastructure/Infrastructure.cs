using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Database;
using Domain.Modules.Category.Repository;
using Domain.Modules.Category.Services;
using Domain.Modules.Faq.Repository;
using Domain.Modules.Faq.Services;
using Infrastructure.Modules.Category.Repositories;
using Infrastructure.Modules.Category.Services;
using Infrastructure.Modules.Faq.Repositories;
using Infrastructure.Modules.Faq.Services;

namespace Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Cấu hình database
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), 
                    mySqlOptions =>
                    {
                        // Cấu hình retry khi lỗi kết nối
                        mySqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null);
                    
                        mySqlOptions.CommandTimeout(30);
                    })
                .EnableSensitiveDataLogging(false)
                .EnableServiceProviderCaching()
                .EnableDetailedErrors();
        });

        // Đăng ký các service
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFaqService, FaqService>();
        services.AddScoped<IFaqRepository, FaqRepository>();

        return services;
    }
}
