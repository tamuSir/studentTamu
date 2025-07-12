
using Microsoft.AspNetCore.Authentication.Cookies;
using studentTamu.Interface;
using studentTamu.Repository;
using System.Data;
using System.Data.SqlClient;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var builder = WebApplication.CreateBuilder(args);
var connectionString = configuration.GetConnectionString($"DBConnection");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IDbConnection>(p => new SqlConnection(connectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //this is for get data directly in index view
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<IStudent, StudentRepo>();
builder.Services.AddScoped<IStudentForm, StudentFormRepo>();
builder.Services.AddScoped<ICompany, CompanyRepo>();
builder.Services.AddScoped<IDocument, DocumentRepo>();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    option =>
    {
        option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        option.LoginPath = "/Accounts/Login";
        option.AccessDeniedPath = "/Accounts/Login";
    });

builder.Services.AddSession(option =>
    { 
        option.IdleTimeout=TimeSpan.FromMinutes(30);
        option.Cookie.HttpOnly = true;
        option.Cookie.IsEssential = true;
    });

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.Map("/studentTamu", builder => builder.UseWebSockets());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Accounts}/{action=Login}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Accounts}/{action=RegisterUserIndex}/{id?}");

});

app.Run();
