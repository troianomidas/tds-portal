namespace WebApp.Models.Subscriptions;

public class SubscriptionModel
{
    public decimal BaseAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal Amount { get; set; }
    public string? Plan { get; set; }
    public int Status { get; set; }
    public int? ReferralId { get; set; }
    public DateTime NextDueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<SubscriptionBilling>? Billings { get; set; }
}

public class SubscriptionBilling
{
    public int SubscriptionId { get; set; }
    public int ChargeId { get; set; }
    public string? BilletLink { get; set; }
    
    public decimal Amount { get; set; }
    public int Status { get; set; }
    public DateTime ExpireAt { get; set; }
    public DateTime CreatedAt { get; set; }
}