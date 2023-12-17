using CQRS.QueriesHandlers.User;
using Domain.Interfaces;
using Infra.Data.Data;
using Infra.Data.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

//config database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connection).UseLazyLoadingProxies();
});

//config para utilizar todos handle do assembly
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(AllUserHandle).Assembly));

//injenções de dependência
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserContractRepository, UserContractRepository>();

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