namespace WebApp.Models.Rewards;

public class ReardSystemModel
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public int? OrderId { get; set; }
    public int? CustomerId { get; set; }
    public int RewardId { get; set; }
    public decimal ValidPoints { get; set; }
    public decimal InvalidPoints { get; set; }
    public DateTime? ExpirationTerm { get; set; }
    public int MovType { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Reward? Reward { get; set; }
}

public class ListRewardTransactionsResponse
{
    public List<ReardSystemModel> Items { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
    public int TotalCount { get; set; }
}

public class Reward
{
    public decimal? PointsCost { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    
    public string GetImageUrl()
    {
        return ImageUrl ?? "/media/svg/files/blank-image.svg";
    }
}