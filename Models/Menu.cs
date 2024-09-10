namespace WebApp.Models;

public class Menu
{
    public Menu(string name, string link, string icon)
    {
        Name = name;
        Link = link;
        Icon = icon;
    }
    
    public string? Name { get; set; }
    public string? Link { get; set; }
    public string? Icon { get; set; }
}