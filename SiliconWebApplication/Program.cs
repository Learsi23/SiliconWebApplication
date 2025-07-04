using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using SiliconWebApplication.Configurations;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(20);
    x.Cookie.IsEssential = true;
    x.Cookie.HttpOnly = true;
});

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

//-------------------------------------------------

builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<AppDbContext>();


//-------------------------------------------

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
    x.AccessDeniedPath = "/denied";

    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;
});
builder.Services.AddAuthentication()
    .AddFacebook(x =>
    {
        x.AppId = "296787203435897";
        x.AppSecret = "244f04473c4dd6487454ad7c8e5c46d9";
        x.Fields.Add("first_name");
        x.Fields.Add("last_name");
    })
    .AddGoogle(options =>
    {
        options.ClientId = "95356781449-2furd7h5pknuvq0gd3klb59ok6fc28ah.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });




var app = builder.Build();
app.UseHsts();
app.UseStatusCodePagesWithReExecute("/Home/Error404", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
