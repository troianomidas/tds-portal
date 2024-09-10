namespace WebApp.Models.Stores;

public class StoreSettingsModel
{
    public string? ExternalId { get; set; }
    public int FilterOrderDateType { get; set; }
    public int FilterOrderSortType { get; set; }
    public int FilterOrderSortAsc { get; set; }
    public decimal OrderMinValue { get; set; }
    public bool IsOpen { get; set; }
    public bool IsPrinterConnected { get; set; }
}