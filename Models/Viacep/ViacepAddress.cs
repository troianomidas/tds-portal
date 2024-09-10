using System.Text.Json.Serialization;

namespace WebApp.Models.Viacep;

public class ViacepAddress
{
    [JsonPropertyName("cep")]
    public string? Zipcode { get; set; }
    
    [JsonPropertyName("logradouro")]
    public string? Line1 { get; set; }
    
    [JsonPropertyName("bairro")]
    public string? Neighborhood { get; set; }
    
    [JsonPropertyName("localidade")]
    public string? City { get; set; }
    
    [JsonPropertyName("uf")]
    public string? State { get; set; }
}