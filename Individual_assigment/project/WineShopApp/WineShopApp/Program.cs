using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using BusinessLogic.RepoInterfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IWineRepo, WineRepo>();
builder.Services.AddScoped<IWineManager, WineManager>();
builder.Services.AddScoped<IAccessoryManager, AccessoryManager>();
builder.Services.AddScoped<IAccessoryRepo, AccessoryRepo>();
builder.Services.AddScoped<IClientManager, ClientManager>();
builder.Services.AddScoped<IClientRepo, ClientRepo>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IProductManager,ProductManager>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Error");
        options.AccessDeniedPath = new PathString("/Cart");

    }
    );


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(2 );
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}


    
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
