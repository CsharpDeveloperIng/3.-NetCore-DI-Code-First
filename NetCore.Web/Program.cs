using Microsoft.EntityFrameworkCore;
using NetCore.Services.Data;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//의존성 주입을 사용하기 위해 서비스를 등록
//IUser 인터페이스에 UserService 클래스 인스턴스 주입
//IUser : 껍데기 UserService : 내용물
builder.Services.AddScoped<IUser, UserService>();
//DB 접속 정보, Migrations 프로젝트를 지정해준다.
builder.Services.AddDbContext<CodeFirstDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString(name:"DefaultConnection"),
                     sqlServerOptionsAction: mig => mig.MigrationsAssembly(assemblyName: "NetCore.Services"))
                      );
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
