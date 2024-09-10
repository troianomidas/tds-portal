namespace WebApp.Models.Catalogs;

public class ProductExtraModel
{
    public ProductExtraModel()
    {
        InternalId = Guid.NewGuid();
        Items = new List<ProductExtraItemModel>();
    }

    public int Id { get; set; }
    public Guid InternalId { get; set; }
    public string? Name { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public bool IsRequired { get; set; }
    public List<ProductExtraItemModel> Items { get; set; }

    //used for front only
    public bool ShowDetail { get; set; }
    public bool IsSelected { get; set; }
    
    public int GetAmount()
    {
        return Items?.Sum(x => x.Amount) ?? 0;
    }
}

public class ProductExtraItemModel
{
    public ProductExtraItemModel() => InternalId = Guid.NewGuid();

    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int Status { get; set; }

    public string GetImageUrl()
    {
        return string.IsNullOrEmpty(ImageUrl) ? "/media/svg/files/blank-image.svg" : ImageUrl;
    }
    
    //used for front only
    public Guid InternalId { get; set; }
    
    public int Amount { get; set; }
}

public class ProductExtraMatchModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }

    public ProductExtraModel ProductExtra { get; set; } = null!;
    public int ProductExtraId { get; set; }
}