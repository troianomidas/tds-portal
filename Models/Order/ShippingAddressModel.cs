namespace WebApp.Models.Order;

public class ShippingAddressModel
{
    public int Id { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? CityState { get; set; }
    public string? Zipcode { get; set; }
}