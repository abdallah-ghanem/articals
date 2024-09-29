using articals.Code;
using articals.Core;
using articals.Data;
using articals.Data.SqlServerEF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Register EmailSender as a singleton service  
builder.Services.AddSingleton<IEmailSender, EmailSender>(); // Add this line to register the EmailSender  
builder.Services.AddScoped<IEmailSender, EmailSender>();


//
builder.Services.AddSingleton<IDataHelper<Catigory>, CatigoryEntity>();


builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("User", p => p.RequireClaim("User", "User"));
    op.AddPolicy("Admin", p => p.RequireClaim("Admin", "Admin"));
});
builder.Services.AddRazorPages();



//
builder.Services.AddMvc(op=>op.EnableEndpointRouting=false);
//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


//add Mvc
app.UseMvcWithDefaultRoute();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();