namespace WebApp.Models.Tickets.TicketAnswers;

public class TicketAnswerModel
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public string? Body { get; set; }
    public int Sort { get; set; }
    public bool IsStoreAnswer { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}