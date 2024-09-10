using WebApp.Models.Stores;

namespace WebApp.Models;

public class AuthModel
{
    public StoreModel? Store { get; set; }
    public string? BearerToken { get; set; }
}