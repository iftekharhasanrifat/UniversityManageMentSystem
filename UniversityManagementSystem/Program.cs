using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces.Manager;
using UniversityManagementSystem.Manager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UniversityMSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityMS")));
builder.Services.AddTransient<IDepartmentManager, DepartmentManager>();
builder.Services.AddTransient<ICourseManager, CourseManager>();
builder.Services.AddTransient<ITeacherManager, TeacherManager>();
builder.Services.AddTransient<IStudentManager, StudentManager>();
builder.Services.AddTransient<IAllocateManager, AllocateManager>();
builder.Services.AddTransient<IEnrollManager, EnrollManager>();
builder.Services.AddTransient<IResultManager, ResultManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
