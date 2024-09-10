namespace WebApp.Models.Customers;

public class CustomerModel
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string? Name { get; set; }
    public long Phone { get; set; }
    public string? Email { get; set; }
    public long? Document { get; set; }
}