using H_Shopping.DAL;
using H_Shopping.ExtendMethods;
using H_Shopping.Mapper;
using H_Shopping.Models;
using H_Shopping.Repository;
using H_Shopping.Repository.IRepository;
using H_Shopping.Services;
using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
//Connection DB
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DBConnection"]);
});
builder.Services.AddRazorPages();

// Add services to the container.
//repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

//service
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ProductImageService>();

//identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
	.AddEntityFrameworkStores<DataContext>()
	.AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity<AppUser>()
//	.AddEntityFrameworkStores<DataContext>()
//	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/login";
});

builder.Services.Configure<IdentityOptions>(options => {
	// Thiết lập về Password
	options.Password.RequireDigit = false; // Không bắt phải có số
	options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
	options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
	options.Password.RequireUppercase = false; // Không bắt buộc chữ in
	options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
	options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

	// Cấu hình Lockout - khóa user
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
	options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lần thì khóa
	options.Lockout.AllowedForNewUsers = true;

	// Cấu hình về User.
	options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
		"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	options.User.RequireUniqueEmail = true;  // Email là duy nhất

	// Cấu hình đăng nhập.
	options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
	options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
	options.SignIn.RequireConfirmedAccount = true;
});

//email
builder.Services.AddOptions();
var mailsetting = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailsetting);
builder.Services.AddSingleton<IEmailSender, SendMailService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Add("/MyView/{1}/{0}.cshtml");
});
GlobalConfig.contentRootPath = builder.Environment.ContentRootPath;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.AddStatusCodePage(); // return status code page with code 400-599

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapAreaControllerRoute(
    name: "admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}",
    areaName: "Admin"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//Seeding data
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedingData(context);

app.Run();

public static class GlobalConfig
{
    public static string contentRootPath { get; set; }
}