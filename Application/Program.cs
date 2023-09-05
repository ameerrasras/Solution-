using Infrastructure.Context;
using Business.Interfaces;
using Business.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Infrastructure.Repository;
using Infrastructure.Entities;

var builder = WebApplication.CreateBuilder(args);
var connectionString =
"Server=localhost;Database=ASALProject;User Id=sa;Password=reallyStrongPwd123;TrustServerCertificate=true;";

builder.Services.AddDbContextPool<MSDBcontext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MSDBcontext>();

builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRoleManager, UserRoleManager>();

builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<UserRole>, Repository<UserRole>>();
builder.Services.AddScoped<IRepository<Department>, Repository<Department>>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
