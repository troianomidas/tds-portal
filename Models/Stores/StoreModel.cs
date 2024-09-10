using WebApp.Models.Subscriptions;
using WebApp.Utils;

namespace WebApp.Models.Stores;

public class StoreModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Hostname { get; set; }
    public string? LogoUrl { get; set; }
    public string? BannerUrl { get; set; }
    public string? Category { get; set; }
    public string? SubCategory { get; set; }
    public string? OwnerName { get; set; }
    public string? OwnerDocument { get; set; }
    public int Status { get; set; }
    
    public SubscriptionModel? Subscription { get; set; }
    public StoreSettingsModel? StoreSettings { get; set; }
    public AddressModel? Address { get; set; }
    public UserModel? User { get; set; }
}