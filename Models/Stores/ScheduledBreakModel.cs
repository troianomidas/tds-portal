namespace WebApp.Models.Stores;

public class ScheduledBreakModel
{
    public Guid InternalId { get; set; } = Guid.NewGuid();
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
}