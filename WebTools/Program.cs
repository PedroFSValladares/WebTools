using Microsoft.EntityFrameworkCore;
using WebTools.Extension;
using WebTools.Hubs;
using WebTools.Services.Implementantions.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.SetUpServices();
builder.Services.AddDbContext<DataBase>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerUrl"))
);
builder.Configuration.SetUpUserSettings();
Environment.SetEnvironmentVariable("BotToken", builder.Configuration["BotToken"]);

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
app.MapHub<DiscordManagementHub>("/discordHub");

app.Run();
