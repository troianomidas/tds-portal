namespace WebApp.Models.ReferralCodes;

public class ReferralCodeModel
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Seller { get; set; }
    public decimal Discount { get; set; }
    public DateTime ValidUntil { get; set; }
    public DateTime CreatedAt { get; set; }
}