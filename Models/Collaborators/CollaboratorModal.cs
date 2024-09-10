namespace WebApp.Models.Collaborators;

public class CollaboratorModal
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? GroupName { get; set; } = "deliveryman";
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Document { get; set; }
    public string? Description { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string GetGroupDescription()
    {
        return GroupName switch
        {
            "deliveryman" => "Entregador",
            "supplier" => "Fornecedor",
            _ => ""
        };
    }
}