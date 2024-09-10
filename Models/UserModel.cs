namespace WebApp.Models;

public class UserModel
{
    public string? ExternalId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PublicIp { get; set; }
    public DateTime? LastAccessAt { get; set; }
    public DateTime? CreatedAt { get; set; }
}