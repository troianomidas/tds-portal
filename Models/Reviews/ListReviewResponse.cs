using WebApp.Models.Order;
namespace WebApp.Models.Reviews;

public class ListReviewResponseSegment
{
    public int OrderId { get; set; }
    public string? Comment { get; set; }
    public DateTime? CreatedAt { get; set; }
    public virtual OrderModel? Order { get; set; }
    public List<Segment>? ReviewSegments { get; set; }
}

public class Segment
{
    public int Group { get; set; }
    public string? GroupName { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}

public class ListReviewResponse
{
    public List<ListReviewResponseSegment> Items { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}

public class OrderModel 
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItemModel>? Items { get; set; }
}
