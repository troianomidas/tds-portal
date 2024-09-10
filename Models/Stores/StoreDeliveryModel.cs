namespace WebApp.Models.Stores;

public class StoreDeliveryModel
{
    public bool HasWithdraw { get; set; }
    public bool HasDelivery { get; set; }
    public bool HasSchedule { get; set; }
    public bool HasDeliveryArea { get; set; }
    public bool HasFreeDelivery { get; set; }
    public decimal FreeDeliveryFrom { get; set; }
    public decimal DeliveryFee { get; set; }
    public int DeliveryTimeMin { get; set; }
    public int DeliveryTimeMax { get; set; }
    public int WithdrawTimeMin { get; set; }
    public int WithdrawTimeMax { get; set; }
}