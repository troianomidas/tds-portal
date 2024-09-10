using System.Security.Claims;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp.Constants;
using WebApp.Models;
using WebApp.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSweetAlert2();
builder.Services.AddScoped<SweetAlert>();

builder.Services.AddScoped<DataRequest>();
builder.Services.AddScoped<IPublicIpService, IpiFyService>();

// builder.Services.AddScoped<IStorageService>(_ =>
//     new StorageBlobService(builder.Configuration.GetConnectionString("Storage") ?? string.Empty));
// builder.Services.AddScoped<IQueueService>(_ =>
//     new StorageQueueService(builder.Configuration.GetConnectionString("Storage") ?? string.Empty));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/";
        options.LogoutPath = "/web/auth/logout";
    });

builder.Services.AddAuthorization(policies =>
{
    policies.AddPolicy(Policies.SubscriptionActive, p => { p.RequireClaim(ClaimTypes.Role, Roles.SubscriptionActive); });
});

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var supportedCultures = new[] { "pt-BR" };

RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures("pt-BR")
    .SetDefaultCulture(supportedCultures[0]);

app.UseRequestLocalization(localizationOptions);

app.Run();