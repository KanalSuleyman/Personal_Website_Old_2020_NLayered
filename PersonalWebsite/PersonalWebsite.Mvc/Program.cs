using PersonalWebsite.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using PersonalWebsite.Services.AutoMapper.Profiles;
using System.Text.Json.Serialization;
using PersonalWebsite.Mvc.AutoMapper.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddSession();

builder.Services.AddAutoMapper(typeof(ArticleProfile), typeof(CategoryProfile), typeof(UserProfile));

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.LoadMyServices();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Admin/User/Login/");
    options.LogoutPath = new PathString("/Admin/User/Logout/");

    options.Cookie = new CookieBuilder
    {
        Name = "PersonalWebsite",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest //Always yapmayi unutma
    };

    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied/");
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.UseSession();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        endpoints.MapAreaControllerRoute(
//                name: "Admin",
//                areaName: "Admin",
//                pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
//            );
//        endpoints.MapDefaultControllerRoute();
//    });
//});

app.Run();




// AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
