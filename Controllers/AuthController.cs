using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApp.Constants;
using WebApp.Models;
using WebApp.Models.Stores;
using WebApp.Utils;

namespace WebApp.Controllers;

[AllowAnonymous]
[Route("web/[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    private readonly string _apiBaseUrl;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IMemoryCache _cache;

    public AuthController(IMemoryCache cache, IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _cache = cache;
        _clientFactory = clientFactory;
        _apiBaseUrl = configuration["ApiBaseUrl"] ?? throw new InvalidOperationException();
    }

    [HttpGet]
    public async Task<IActionResult> Login(string? hash)
    {
        if (string.IsNullOrEmpty(hash))
            return BadRequest();
        
        if (!_cache.TryGetValue(hash, out string? userExternalId))
            return BadRequest();
        
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        HttpClient client = _clientFactory.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync($"{_apiBaseUrl}/v1/account/login", new
        {
            UserExternalId = userExternalId
        });
        if (!response.IsSuccessStatusCode)
        {
            return await Logout();
        }
        
        var auth = await response.Content.ReadFromJsonAsync<AuthModel?>();
        if (auth?.Store?.User == null)
            return await Logout();

        var claimList = new List<Claim>
        {
            new(ClaimTypes.Authentication, auth.BearerToken ?? string.Empty),
            new(ClaimTypes.NameIdentifier, auth.Store.User.ExternalId ?? string.Empty),
            new(ClaimTypes.Surname, auth.Store.Name ?? string.Empty),
            new(ClaimTypes.Email, auth.Store.User.Email ?? string.Empty),
            // new(ClaimTypes.Actor, auth.Store.LogoUrl ?? $"{StorageConst.FrontDoor}/portal/assets/media/avatars/blank.png"),
        };
        
        if (auth.Store.Status is 1 or 2)
            claimList.Add(new Claim(ClaimTypes.Role, Roles.SubscriptionActive));
        
        ClaimsIdentity claimsIdentity = new(claimList, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(12),
                IsPersistent = false
            });
        
        _cache.Remove(hash);

        return LocalRedirectPermanent("/");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return LocalRedirectPermanent("/");
    }
    
    [HttpGet]
    public async Task<IActionResult> Rewrite()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return LocalRedirectPermanent("/");
    }
}