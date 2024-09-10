using WebApp.Models.Catalogs;

namespace WebApp.Models.Categories;

public class CategoryModel
{
    public CategoryModel() => Products = new List<ProductModel>();

    public int Id { get; set; }
    public int StoreId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Sort { get; set; }
    public int Status { get; set; }
    public List<ProductModel> Products { get; set; }
    
    
    //used for front only
    public bool IsEdit { get; set; }
    public bool Collapsed { get; set; }
}