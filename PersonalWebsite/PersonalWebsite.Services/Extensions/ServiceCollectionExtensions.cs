using Microsoft.Extensions.DependencyInjection;
using PersonalWebsite.Data.Abstract;
using PersonalWebsite.Data.Concrete;
using PersonalWebsite.Data.Concrete.EntityFramework.Contexts;
using PersonalWebsite.Entities.Concrete;
using PersonalWebsite.Services.Abstract;
using PersonalWebsite.Services.Concrete;

namespace PersonalWebsite.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<PersonalWebsiteContext>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddIdentity<User, Role>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // User settings.
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<PersonalWebsiteContext>();
        serviceCollection.AddScoped<ICategoryService, CategoryManager>();
        serviceCollection.AddScoped<IArticleService, ArticleManager>();
        return serviceCollection;
    }
}