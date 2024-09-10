namespace WebApp.Models;

public class Announcement
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public int Type { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
}