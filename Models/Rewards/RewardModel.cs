namespace WebApp.Models.Rewards;

public class RewardModel
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public decimal? PointsCost { get; set; }
    public string? Description { get; set; }
    public int Status { get; set; }
    public string? ImageUrl { get; set; }
    
    public string GetImageUrl()
    {
        return ImageUrl ?? "/media/svg/files/blank-image.svg";
    }
}