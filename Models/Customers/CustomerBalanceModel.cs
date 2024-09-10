namespace WebApp.Models.Customers;

public class CustomerBalanceModel
{
    public int? CustomerId { get; set; }
    public int StoreId { get; set; }
    public string? Name { get; set; }
    public long Phone { get; set; }
    public string? Email { get; set; }
    public long Document { get; set; }
    public decimal QuantsoPoints { get; set; }
    public decimal BalancePoints { get; set; }
}