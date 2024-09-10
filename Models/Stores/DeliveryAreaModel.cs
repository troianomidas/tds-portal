namespace WebApp.Models.Stores;

public class DeliveryAreaModel
{
    public Guid InternalId { get; set; } = Guid.NewGuid();
    public int Id { get; set; }
    public int StoreId { get; set; }
    public string? Name { get; set; }
    public decimal Fee { get; set; }
}