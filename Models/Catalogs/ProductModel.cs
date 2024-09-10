namespace WebApp.Models.Catalogs;

public class ProductModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Sku { get; set; }
    public string? BarcodeEan { get; set; }
    public decimal UnitPrice { get; set; }
    public bool Stockable { get; set; }
    public int? AvailableStock { get; set; }
    public int DiscountType { get; set; } = 1;
    public decimal Discount { get; set; }
    public int Status { get; set; } = 1;
    public int? CategoryId { get; set; }
    public int? CollaboratorId { get; set; }
    public bool IsProductIndustrialized { get; set; }
    public string? Weight { get; set; }
    public string? WeightType { get; set; } = "g";
    public int ServesHowManyPeople { get; set; }
    public string? ImageUrl { get; set; }
    public bool HasAvailability { get; set; }
    public bool HasExtra { get; set; }
    public bool Highlights { get; set; }
    public List<ProductExtraMatchModel> ProductExtraMatches { get; set; } = new();

    public string GetImageUrl()
    {
        return ImageUrl ?? "/media/svg/files/blank-image.svg";
    }
    
    public decimal GetUnitPriceWithDiscount()
    {
        decimal discount = DiscountType switch
        {
            2 => UnitPrice / Discount,
            3 => Discount,
            _ => 0
        };

        return UnitPrice - discount;
    }
}