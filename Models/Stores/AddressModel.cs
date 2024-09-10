namespace WebApp.Models.Stores;

public class AddressModel
{
    public int Id { get; set; }
    public string? Zipcode { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
}