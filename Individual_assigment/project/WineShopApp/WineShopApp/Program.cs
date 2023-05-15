using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);



//builder.Services.AddSingleton<IWineRepo, WineManagment>();

//builder.Services.AddSingleton<IAccessoryManager,AccessoryManager>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Error");

    }
    );


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



    

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
